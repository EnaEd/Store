using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.BusinessLogicLayer.Interfaces;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Services
{
    public class JWTService : IJWTService
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private const string AUTH_TYPE = "Token";
        private readonly TokenValidationParameters _tokenValidationParameters;
        public JWTService(IUserRepository<User> userRepository, IConfiguration configuration, IMapper mapper,
            TokenValidationParameters tokenValidationParameters)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
            _tokenValidationParameters = tokenValidationParameters;
        }
        public static SymmetricSecurityKey GetSymmetricSecurityKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        }

        public async Task<(string accessToken, string refreshToken)> GetTokensAsync(string userEmail)
        {
            User user = await _userRepository.GetOneAsync(userEmail);

            var userClaim = await GetIdentityAsync(user);

            if (userClaim is null)
            {
                return (null, null);
            }

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _configuration["AuthOptions:Issuer"],
                audience: _configuration["AuthOptions:Audience"],
                notBefore: now,
                claims: userClaim.Claims,
                expires: now.Add(TimeSpan.FromMinutes(double.Parse(_configuration["AuthOptions:LifeTime"]))),
                signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(_configuration["AuthOptions:Key"]),
                                                           SecurityAlgorithms.HmacSha256));
            user.RefreshToken = Guid.NewGuid().ToString();
            await _userRepository.UpdateAsync(user);
            return (new JwtSecurityTokenHandler().WriteToken(token), user.RefreshToken);
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(User user)
        {
            var userRoles = await _userRepository.GetUserRolesAsync(user);

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.AddRange(userRoles.Select(item => new Claim(ClaimsIdentity.DefaultRoleClaimType, item)));

            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, AUTH_TYPE, ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        //TODO EE: change tuple on model
        public async Task<(string accessToken, string refreshToken)> RefreshTokensAsync(string accessToken, string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var encryptToken = tokenHandler.ReadToken(accessToken) as JwtSecurityToken;
            var mail = encryptToken.Claims.Single(claim => claim.Type == ClaimTypes.Email).Value;
            User user = await _userRepository.GetOneAsync(mail);
            if (user is null)
            {
                //TODO EE: add error
                return (null, null);
            }
            if (!user.RefreshToken.Equals(refreshToken))
            {
                return (null, null);
            }
            var resultTokens = await GetTokensAsync(mail);

            return (resultTokens.accessToken, resultTokens.refreshToken);
        }
    }
}
