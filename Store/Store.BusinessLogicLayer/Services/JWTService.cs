using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Tokens;
using Store.DataAccessLayer.Entities;
using Store.Shared.Common;
using Store.Shared.Constants;
using Store.Shared.Enums;
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
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private const string AUTH_TYPE = "Token";
        public JWTService(IConfiguration configuration, UserManager<User> userManager)
        {

            _configuration = configuration;
            _userManager = userManager;
        }
        public static SymmetricSecurityKey GetSymmetricSecurityKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        }

        public async Task<TokenResponseModel> GetTokensAsync(string userEmail)
        {
            TokenResponseModel responseModel = new TokenResponseModel();
            User user = await _userManager.FindByEmailAsync(userEmail);
            if (user is null)
            {
                throw new UserException(Constant.Errors.USER_NOT_EXISTS, Enums.ErrorCode.BadRequest);
            }

            var userClaim = await GetIdentityAsync(user);

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
            await _userManager.UpdateAsync(user);

            responseModel.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
            responseModel.RefreshToken = user.RefreshToken;
            return responseModel;
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(User user)
        {

            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };
            claims.AddRange(userRoles.Select(item => new Claim(ClaimsIdentity.DefaultRoleClaimType, item)));

            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, AUTH_TYPE, ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        public async Task<TokenResponseModel> RefreshTokensAsync(string accessToken, string refreshToken)
        {
            TokenResponseModel responseModel = new TokenResponseModel();
            var tokenHandler = new JwtSecurityTokenHandler();
            var encryptToken = tokenHandler.ReadToken(accessToken) as JwtSecurityToken;
            string mail = encryptToken.Claims.Single(claim => claim.Type == ClaimTypes.Email).Value;
            User user = await _userManager.FindByEmailAsync(mail);
            if (user is null)
            {
                throw new UserException(Constant.Errors.USER_NOT_EXISTS, Enums.ErrorCode.BadRequest);
            }
            if (!user.RefreshToken.Equals(refreshToken))
            {
                throw new UserException(Constant.Errors.USER_NOT_EXISTS, Enums.ErrorCode.BadRequest);
            }
            TokenResponseModel resultTokens = await GetTokensAsync(mail);

            return resultTokens;
        }
    }
}
