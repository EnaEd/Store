using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Users;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("getfiltereduser")]
        public async Task<IActionResult> GetFilteredUsers()
        {
            return Ok(await _adminService.GetFilteredUserProfileModelsAsync());
        }

        [HttpPost("getfiltereduser")]
        public async Task<IActionResult> GetFilteredUsers([FromBody]UserFilterModel filter)
        {
            return Ok(await _adminService.GetFilteredUserProfileModelsAsync(filter));
        }

        [HttpPost("setblockuser")]
        public async Task<IActionResult> SetBlockUser([FromBody]UserModel user)
        {
            await _adminService.SetBlockUserAsync(user);
            return Ok();
        }
    }
}
