using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Users;
using System.Threading.Tasks;

namespace Store.Admin.Controllers
{
    public class SignInController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IAdminService _adminService;

        public SignInController(IAccountService accountService, IAdminService adminService)
        {
            _accountService = accountService;
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserModel requestModel)
        {
            var response = await _accountService.SignInAsync(requestModel);

            await _adminService.Authenticate(response);

            return Redirect("~/Admin/index");
        }
    }
}
