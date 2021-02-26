using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Tokens;
using Store.BusinessLogicLayer.Models.Users;
using Store.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.BusinessLogicLayer.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private IHttpContextAccessor _contextAccessor;

        public AdminService(IMapper mapper, IHttpContextAccessor contextAccessor, UserManager<User> userManager)
        {

            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public async Task Authenticate(TokenResponseModel tokenResponseModel)
        {
            var jwtToken = new JwtSecurityToken(tokenResponseModel.AccessToken);
            var claims = jwtToken.Claims.Where(x => x.Type.EndsWith("role") || x.Type.EndsWith("emailaddress"));

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return;
        }

        public async Task<IEnumerable<UserProfileModel>> GetFilteredUserProfileModelsAsync(UserFilterModel userFilterModel = null)
        {

            //return _mapper.Map<IEnumerable<UserProfileModel>>(
            //    await _userRepository.GetFilteredUserProfilesAsync(_mapper.Map<UserFilterEntity>(userFilterModel)));
            throw new NotImplementedException();
        }

        public async Task<UserProfileModel> GetProfileModelByUserAsync(UserModel user)
        {
            throw new NotImplementedException();
            //var filter = new UserFilterEntity
            //{
            //    Email = user.Email
            //};

            //UserProfileModel userProfile = _mapper.Map<IEnumerable<UserProfileModel>>(
            //        await _userRepository.GetFilteredUserProfilesAsync(filter)).FirstOrDefault();

            //if (userProfile is null)
            //{
            //    throw new UserException(Constant.Errors.USER_NOT_EXISTS, Enums.ErrorCode.BadRequest);
            //}
            //return userProfile;

        }

        public async Task SetBlockUserAsync(UserModel userModel)
        {
            throw new NotImplementedException();
            //User user = await _userRepository.GetOneAsync(userModel.Email);
            //if (user is null)
            //{
            //    throw new UserException(Constant.Errors.USER_NOT_EXISTS, Enums.ErrorCode.BadRequest);
            //}
            //user.IsBlocked = !user.IsBlocked;
            //await _userRepository.UpdateAsync(user);
        }
    }
}
