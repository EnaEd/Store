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
        private readonly IValidationProvider _validationProvider;




        public AccountService(IMapper mapper,
            SignInManager<User> signInManager, IJWTService jWTService, UserManager<User> userManager,
            IEmailProvider emailProvider, IValidationProvider validationProvider)
        {

            _mapper = mapper;
            _signInManager = signInManager;
            _jWTService = jWTService;
            _userManager = userManager;
            _emailProvider = emailProvider;
            _validationProvider = validationProvider;
        }

        public async Task ConfirmEmailAsync(ConfirmEmailRequestModel model)
        {
            if (!_validationProvider.TryValidate(model, out List<string> errors))
            {
                throw new UserException(errors, Enums.ErrorCode.BadRequest);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
            {
                throw new UserException(Constant.Errors.USER_NOT_EXISTS, Enums.ErrorCode.NotFound);
            }

            var confirmResult = await _userManager.ConfirmEmailAsync(user, model.Code);
            if (confirmResult.Errors.Any())
            {
                throw new UserException(confirmResult.Errors.Select(error => error.Description).ToList(), Enums.ErrorCode.BadRequest);
            }
        }

        public async Task ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel)
        {
            if (!_validationProvider.TryValidate(forgotPasswordModel, out List<string> errors))
            {
                throw new UserException(errors, Enums.ErrorCode.BadRequest);
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

            string newPassword = _validationProvider.GenerateTempPassword();

            var resetResult = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (resetResult.Errors.Any())
            {
                throw new UserException(resetResult.Errors.Select(error => error.Description).ToList(), Enums.ErrorCode.BadRequest);
            }

            await _emailProvider.SendEmailAsync(user.Email, Constant.Common.MAIL_SUBJECT_TEXT, string.Format(Constant.Common.MAIL_MESSAGE_FORGOT_PASSWORD_TEXT, newPassword));
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var result = _mapper.Map<IEnumerable<UserModel>>(await _userManager.Users.ToListAsync());
            return result;
        }

        public async Task<TokenResponseModel> SignInAsync(SignInRequestModel userModel)
        {
            if (!_validationProvider.TryValidate(userModel, out List<string> errors))
            {
                throw new UserException(errors, Enums.ErrorCode.Unauthorized);
            }

            User user = await _userManager.FindByEmailAsync(userModel.Email);
            if (user is null)
            {
                throw new UserException(Constant.Errors.WRONG_EMAIL_ERROR, Enums.ErrorCode.Unauthorized);
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, userModel.Password, userModel.RememberMe, false);
            if (!result.Succeeded)
            {
                string error = result.IsNotAllowed ? Constant.Errors.EMAIL_NOT_CONFIRM : Constant.Errors.WRONG_PASSWORD_ERROR;
                throw new UserException(error, Enums.ErrorCode.Unauthorized);
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
            if (!_validationProvider.TryValidate<UserModel>(userModel, out List<string> errors))
            {
                throw new UserException(errors, Enums.ErrorCode.Unauthorized);
            }

            var mappedEntity = _mapper.Map<User>(userModel);
            var result = await _userManager.CreateAsync(mappedEntity, userModel.Password);
            if (result.Errors.Any())
            {
                throw new UserException(result.Errors.Select(error => error.Description).ToList(), Enums.ErrorCode.BadRequest);
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

            var uriBuilder = new UriBuilder(Constant.Common.MAIL_CALLBACK_URL);
            var paramValues = HttpUtility.ParseQueryString(uriBuilder.Query);
            paramValues.Add(Constant.Common.MAIL_PARAM_EMAIL, $"{userModel.Email}");
            paramValues.Add(Constant.Common.MAIL_PARAM_CODE, $"{confirmToken}");
            uriBuilder.Query = paramValues.ToString();

            await _emailProvider.SendEmailAsync(userModel.Email,
                Constant.Common.MAIL_SUBJECT_TEXT,
                string.Format(Constant.Common.MAIL_MESSAGE_CONFIRM_EMAIL_TEXT, uriBuilder.Uri));
        }
    }
}
