using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Users;
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
        public AccountController(IAccountService accountService, IEmailService emailService, IConfiguration configuration)
        {
            _accountService = accountService;
            _emailService = emailService;
            _configuration = configuration;
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
        public async Task<string> SignIn([FromBody]UserModel value)
        {
            var res = await _accountService.SignInAsync(value);
            return res ? "signin success" : "signin not success";
        }

        [HttpGet("confirmemail")]
        public async Task<IActionResult> ConfirmEmail(string email, string code)
        {
            return await _accountService.ConfirmEmailAsync(email, code) ?
                Content("verification success") :
                Content("verification error");
        }

    }
}
