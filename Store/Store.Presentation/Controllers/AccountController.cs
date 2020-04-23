using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Tokens;
using Store.BusinessLogicLayer.Models.Users;
using Store.Shared.Enums;
using Store.Shared.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
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

        [HttpGet]
        public async Task<IEnumerable<UserModel>> Get()
        {

            return await _accountService.GetUsers();
        }

        [HttpGet("signout")]
        public async Task<string> SignOut()
        {
            await _accountService.SignOutAsync();
            return "signout completed";
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]UserModel value)
        {

            var result = await _accountService.SigUpAsync(value);

            if (result)
            {
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

                return Content("we send you email for confirm registration");
            }

            return Content("error");
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody]UserModel value)
        {
            var res = await _accountService.SignInAsync(value);
            if (!res)
            {
                return BadRequest();
            }
            var result = await _jWTService.GetTokensAsync(value.Email);
            return Ok(new { accessToken = result.accessToken, refreshToken = result.refreshToken });
        }

        [HttpGet("confirmemail")]
        public async Task<IActionResult> ConfirmEmail(string email, string code)
        {
            return await _accountService.ConfirmEmailAsync(email, code) ?
                Content("verification success") :
                Content("verification error");
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel forgotPasswordModel)
        {
            string resetToken = await _accountService.ForgotPasswordAsync(forgotPasswordModel);
            if (resetToken is null)
            {
                //TODO EE: return correct error
                throw new System.Exception(ErrorCode.BadRequest.GetAttribute<EnumDescriptor>().Description);
            }
            string password = _accountService.GenerateTempPassword();
            if (!await _accountService.ResetPasswordAsync(forgotPasswordModel.Email, resetToken, password))
            {
                return Content("reset password failed");
            }
            string callbackUrl = Url.Action(
                "ResetPassword",
                "Account",
                 new { email = forgotPasswordModel.Email, code = resetToken },
                 protocol: HttpContext.Request.Scheme);
            await _emailService.SendEmailAsync(forgotPasswordModel.Email,
                    _configuration["RequestEmail:ThemeMail"],
                    $"your new password <br> <div> {password} <div/>");

            return Content("we generated to u link for reset password");
        }

        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody]TokenRequestModel tokenRequestModel)
        {
            var result = await _jWTService.RefreshTokensAsync(tokenRequestModel.AccessToken, tokenRequestModel.RefreshToken);
            return Ok(new { accessToken = result.accessToken, refreshToken = result.refreshToken });
        }

    }
}
