using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Presentation.Controller
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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
        public async Task<string> SignUp([FromBody]UserModel value)
        {
            var res = await _accountService.SigUpAsync(value);

            return res ? "we are send you email for verification" : "signup not success";
        }

        [HttpPost("signin")]
        public async Task<string> SignIn([FromBody]UserModel value)
        {
            var res = await _accountService.SignInAsync(value);

            return res ? "signin success" : "signin not success";
        }

    }
}
