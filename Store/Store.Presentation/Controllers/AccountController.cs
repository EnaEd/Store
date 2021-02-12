using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Tokens;
using Store.BusinessLogicLayer.Models.Users;
using Store.BusinessLogicLayer.Providers.Interfaces;
using Store.Shared.Constants;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Presentation.Controllers
{
    [Route(Constant.Routes.DEFAULT_API_ROUTE)]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IEmailProvider _emailService;
        private readonly IConfiguration _configuration;
        private readonly IJWTService _jWTService;
        private readonly IAdminService _adminService;
        public AccountController(IAccountService accountService, IEmailProvider emailService, IConfiguration configuration,
            IJWTService jWTService, IAdminService adminService)
        {
            _accountService = accountService;
            _emailService = emailService;
            _configuration = configuration;
            _jWTService = jWTService;
            _adminService = adminService;
        }

        [HttpGet(Constant.Routes.GET_ACCOUNTS_ROUTE)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _adminService.GetFilteredUserProfileModelsAsync());
        }

        [HttpGet(Constant.Routes.SIGN_OUT_ROUTE)]
        public async Task<IActionResult> SignOutAsync()
        {
            await _accountService.SignOutAsync();
            return Ok(Constant.Info.SIGN_OUT_SUCCESS);
        }

        [HttpGet(Constant.Routes.CONFIRM_MAIL_ROUTE)]
        public async Task<IActionResult> ConfirmEmailAsync(string email, string code)
        {
            await _accountService.ConfirmEmailAsync(email, code);
            return Ok(Constant.Info.CONFIRM_MAIL_SUCCESS);
        }

        [HttpPost(Constant.Routes.SIGN_UP_ROUTE)]
        public async Task<IActionResult> SignUpAsync([FromBody] UserModel model)
        {
            await _accountService.SigUpAsync(model);

            string token = await _accountService.GenerateEmailConfirmTokenAsync(model);
            string callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { email = model.Email, code = token },
                        protocol: HttpContext.Request.Scheme
                        );
            await _emailService.SendEmailAsync(model.Email,
                _configuration["RequestEmail:ThemeMail"],
                $"click this link for confirm registration <br> <a href='{callbackUrl}'> Confirm mail <a/>");

            return Ok(Constant.Info.CONFIRM_MAIL_FOR_REGISTRATION_SUCCESS);
        }

        [HttpPost(Constant.Routes.SIGN_IN_ROUTE)]
        public async Task<IActionResult> SignInAsync([FromBody] UserModel value)
        {
            TokenResponseModel result = await _accountService.SignInAsync(value);
            return Ok(result);
        }

        [HttpPost(Constant.Routes.FORGOT_PASSWORD_ROUTE)]
        public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPasswordModel forgotPasswordModel)
        {
            string resetToken = await _accountService.ForgotPasswordAsync(forgotPasswordModel);

            string password = _accountService.GenerateTempPassword();

            await _accountService.ResetPasswordAsync(forgotPasswordModel.Email, resetToken, password);
            _ = Url.Action(
                "ResetPassword",
                "Account",
                 new { email = forgotPasswordModel.Email, code = resetToken },
                 protocol: HttpContext.Request.Scheme);
            await _emailService.SendEmailAsync(forgotPasswordModel.Email,
                    _configuration["RequestEmail:ThemeMail"],
                    $"your new password <br> <div> {password} <div/>");

            return Ok(Constant.Info.SEND_RESET_PASSWORD_MAIL_SUCCESS);
        }

        [HttpPost(Constant.Routes.REFRESH_TOKEN_ROUTE)]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] TokenRequestModel tokenRequestModel)
        {
            TokenResponseModel result = await _jWTService.RefreshTokensAsync(tokenRequestModel.AccessToken, tokenRequestModel.RefreshToken);
            return Ok(result);
        }

    }
}
