using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Tokens;
using Store.BusinessLogicLayer.Models.Users;
using Store.DataAccessLayer.Entities;
using Store.Shared.Common;
using Store.Shared.Constants;
using Store.Shared.Enums;
using Store.Shared.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Store.BusinessLogicLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJWTService _jWTService;
        private readonly IEmailProvider _emailProvider;




        public AccountService(IMapper mapper,
            SignInManager<User> signInManager, IJWTService jWTService, UserManager<User> userManager, IEmailProvider emailProvider)
        {

            _mapper = mapper;
            _signInManager = signInManager;
            _jWTService = jWTService;
            _userManager = userManager;
            _emailProvider = emailProvider;
        }

        public async Task ConfirmEmailAsync(string email, string code)
        {
            if (email is null || code is null)
            {
                throw new UserException(Constant.Errors.EMPTY_FIELD, Enums.ErrorCode.BadRequest);
            }

            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                throw new UserException(Constant.Errors.USER_NOT_EXISTS, Enums.ErrorCode.NotFound);
            }

            var confirmResult = await _userManager.ConfirmEmailAsync(user, code);
            if (confirmResult.Errors.Any())
            {
                throw new UserException(confirmResult.Errors.Select(error => error.Description).ToList(), Enums.ErrorCode.BadRequest);
            }
        }

        public async Task<string> ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel)
        {
            if (forgotPasswordModel is null || string.IsNullOrWhiteSpace(forgotPasswordModel.Email))
            {
                throw new UserException(Constant.Errors.EMPTY_FIELD, Enums.ErrorCode.BadRequest);
            }

            var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email);
            if (user is null)
            {
                throw new UserException(Constant.Errors.USER_NOT_EXISTS, Enums.ErrorCode.BadRequest);
            }

            if (!(await _userManager.IsEmailConfirmedAsync(user)))
            {
                throw new UserException(Constant.Errors.EMAIL_NOT_CONFIRM, Enums.ErrorCode.BadRequest);
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new UserException(Constant.Errors.GENERATE_TOKEN_FAIL, Enums.ErrorCode.BadRequest);
            }

            return token;
        }

        public async Task<string> GenerateEmailConfirmTokenAsync(UserModel userModel)
        {
            if (userModel is null || string.IsNullOrWhiteSpace(userModel.Email))
            {
                throw new UserException(Constant.Errors.EMPTY_FIELD, Enums.ErrorCode.BadRequest);
            }
            var user = await _userManager.FindByEmailAsync(userModel.Email);
            if (user is null)
            {
                throw new UserException(Constant.Errors.USER_NOT_EXISTS, Enums.ErrorCode.BadRequest);
            }
            string confirmToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if (string.IsNullOrWhiteSpace(confirmToken))
            {
                throw new UserException(Constant.Errors.CONFIRM_EMAIL_FAIL, Enums.ErrorCode.BadRequest);
            }

            return confirmToken;
        }

        public string GenerateTempPassword()
        {
            string pattern = @"(?=.*[0 - 9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*]{16,}";
            string password = GeneratePassword();
            while (Regex.IsMatch(password, pattern))
            {
                password = GeneratePassword();
            }

            return password;
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var result = _mapper.Map<IEnumerable<UserModel>>(await _userManager.Users.ToListAsync());
            return result;
        }

        public async Task<TokenResponseModel> SignInAsync(UserModel userModel)
        {
            //TODO EE: add new validation
            List<string> errors = new();

            if (userModel is null)
            {
                throw new UserException(Constant.Errors.EMPTY_FIELD, Enums.ErrorCode.Unauthorized);
            }
            if (string.IsNullOrWhiteSpace(userModel.Email))
            {
                throw new UserException(Constant.Errors.EMPTY_FIELD, Enums.ErrorCode.Unauthorized);
            }
            if (string.IsNullOrWhiteSpace(userModel.Password))
            {
                throw new UserException(Constant.Errors.EMPTY_FIELD, Enums.ErrorCode.Unauthorized);
            }

            User user = await _userManager.FindByEmailAsync(userModel.Email);
            if (user is null)
            {
                errors.Add(Constant.Errors.WRONG_EMAIL_ERROR);
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, userModel.Password, userModel.RememberMe, false);
            if (!result.Succeeded)
            {
                errors.Add(Constant.Errors.WRONG_PASSWORD_ERROR);
            }

            if (errors.Any())
            {
                throw new UserException(errors, Enums.ErrorCode.Unauthorized);
            }

            TokenResponseModel responseModel = await _jWTService.GetTokensAsync(userModel.Email);
            return responseModel;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task SigUpAsync(UserModel userModel)
        {
            if (userModel is null)
            {
                throw new UserException(Constant.Errors.EMPTY_FIELD, Enums.ErrorCode.Unauthorized);
            }
            if (string.IsNullOrWhiteSpace(userModel.Email))
            {
                throw new UserException(Constant.Errors.EMPTY_FIELD, Enums.ErrorCode.Unauthorized);
            }
            if (string.IsNullOrWhiteSpace(userModel.Password))
            {
                throw new UserException(Constant.Errors.EMPTY_FIELD, Enums.ErrorCode.Unauthorized);
            }
            if (string.IsNullOrWhiteSpace(userModel.FirstName))
            {
                throw new UserException(Constant.Errors.EMPTY_FIELD, Enums.ErrorCode.Unauthorized);
            }
            if (string.IsNullOrWhiteSpace(userModel.LastName))
            {
                throw new UserException(Constant.Errors.EMPTY_FIELD, Enums.ErrorCode.Unauthorized);
            }

            var mappedEntity = _mapper.Map<User>(userModel);

            var result = await _userManager.CreateAsync(mappedEntity, userModel.Password);
            if (result.Errors.Any())
            {
                throw new UserException(result.Errors.Select(error => error.Description).ToList(), Enums.ErrorCode.BadRequest);
            }


            string token = await GenerateEmailConfirmTokenAsync(userModel);


            var uriBuilder = new UriBuilder($"http://localhost:56932/api/account/confirmemail");
            var paramValues = HttpUtility.ParseQueryString(uriBuilder.Query);
            paramValues.Add("email", $"{userModel.Email}");
            paramValues.Add("code", $"{token}");
            uriBuilder.Query = paramValues.ToString();

            await _emailProvider.SendEmailAsync(userModel.Email,
                "Verification mail",
                $"click this link for confirm registration <br> <a href='{uriBuilder.Uri}'> Confirm mail <a/>");

        }

        public string GeneratePassword()
        {
            //TODO EE: make better generation password
            string password = string.Empty;
            int[] array = new int[Constant.PasswordConfig.PASSWORD_LENGTH];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(Constant.PasswordConfig.COMMON_SIMBOLS_RANGE_START, Constant.PasswordConfig.COMMON_SIMBOLS_RANGE_END);
                password += (char)array[i];
            }
            return password;
        }

        public async Task ResetPasswordAsync(string email, string token, string password)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(token) ||
                string.IsNullOrWhiteSpace(password))
            {
                throw new UserException(Constant.Errors.EMPTY_FIELD, Enums.ErrorCode.BadRequest);
            }
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                throw new UserException(Constant.Errors.USER_NOT_EXISTS, Enums.ErrorCode.BadRequest);
            }

            var resetResult = await _userManager.ResetPasswordAsync(user, token, password);
            if (resetResult.Errors.Any())
            {
                throw new UserException(resetResult.Errors.Select(error => error.Description).ToList(), Enums.ErrorCode.BadRequest);
            }
        }
    }
}
