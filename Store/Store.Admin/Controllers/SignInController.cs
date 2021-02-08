using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogicLayer.Models.Users;
using System.Threading.Tasks;

namespace Store.Admin.Controllers
{
    public class SignInController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserModel requestModel)
        {

            return View();
        }
    }
}
