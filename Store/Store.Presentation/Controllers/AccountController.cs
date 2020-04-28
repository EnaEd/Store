using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Tokens;
using Store.BusinessLogicLayer.Models.Users;
using Store.Shared.Constants;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly IJWTService _jWTService;
        public AccountController(IAccountService accountService, IEmailService emailService, IConfiguration configuration,
            IJWTService jWTService)
        {
            _accountService = accountService;
            _emailService = emailService;
            _configuration = configuration;
            _jWTService = jWTService;
        }


        [HttpGet("signout")]
        public async Task<IActionResult> SignOut()
        {
            await _accountService.SignOutAsync();
            return Ok();
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]UserModel value)
        {
            await _accountService.SigUpAsync(value);

            string token = await _accountService.GenerateEmailConfirmTokenAsync(value);
            var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { email = value.Email, code = token },
                        protocol: HttpContext.Request.Scheme
                        );
            await _emailService.SendEmailAsync(value.Email,
                _configuration["RequestEmail:ThemeMail"],
                $"click this link for confirm registration <br> <a href='{callbackUrl}'> Confirm mail <a/>");

            return Ok("we send you email for confirm registration");
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody]UserModel value)
        {
            await _accountService.SignInAsync(value);
            TokenResponseModel result = await _jWTService.GetTokensAsync(value.Email);
            return Ok(result);
        }

        [HttpGet("confirmemail")]
        public async Task<IActionResult> ConfirmEmail(string email, string code)
        {
            await _accountService.ConfirmEmailAsync(email, code);
            return Ok();
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel forgotPasswordModel)
        {
            string resetToken = await _accountService.ForgotPasswordAsync(forgotPasswordModel);

            string password = _accountService.GenerateTempPassword();

            await _accountService.ResetPasswordAsync(forgotPasswordModel.Email, resetToken, password);

            string callbackUrl = Url.Action(
                "ResetPassword",
                "Account",
                 new { email = forgotPasswordModel.Email, code = resetToken },
                 protocol: HttpContext.Request.Scheme);
            await _emailService.SendEmailAsync(forgotPasswordModel.Email,
                    _configuration["RequestEmail:ThemeMail"],
                    $"your new password <br> <div> {password} <div/>");

            return Ok(InfoConstatnts.SEND_CONFIRM_MAIL_INFO);
        }

        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody]TokenRequestModel tokenRequestModel)
        {
            TokenResponseModel result = await _jWTService.RefreshTokensAsync(tokenRequestModel.AccessToken, tokenRequestModel.RefreshToken);
            return Ok(result);
        }

    }
}
