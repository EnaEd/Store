using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Users;
using Store.Shared.Constants;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [Route(Constant.Routes.DEFAULT_API_ROUTE)]
    [Authorize(Roles = Constant.AuthRoles.ADMIN_ROLE)]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost(Constant.Routes.GET_USERS_ROUTE)]
        public async Task<IActionResult> GetFilteredUsersAsync([FromBody] UserFilterModel filter)
        {
            var result = await _adminService.GetFilteredUserProfileModelsAsync();
            return Ok(result);
        }

        [HttpPost(Constant.Routes.BLOCK_USER_ROUTE)]
        public async Task<IActionResult> SetBlockUserAsync([FromBody] UserModel user)
        {
            await _adminService.SetBlockUserAsync(user);
            return Ok();
        }
    }
}
