using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Users;
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
        public JWTService(IUserRepository<User> userRepository, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }
        public static SymmetricSecurityKey GetSymmetricSecurityKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        }

        public async Task<string> GetTokenAsync(UserModel userSource)
        {
            User user = await _userRepository.GetOneAsync(_mapper.Map<User>(userSource));

            var userClaim = await GetIdentity(user);

            if (userClaim is null)
            {
                return null;
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

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<ClaimsIdentity> GetIdentity(User user)
        {
            var userRoles = await _userRepository.GetUserRolesAsync(user);

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email));
            claims.AddRange(userRoles.Select(item => new Claim(ClaimsIdentity.DefaultRoleClaimType, item)));

            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, AUTH_TYPE, ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
