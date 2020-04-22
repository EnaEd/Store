using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return Content("home");
        }

        [Authorize]
        [HttpGet("auth")]
        public IActionResult AuthTest()
        {
            return Ok("Auth ok");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("authadmin")]
        public IActionResult AuthadminTest()
        {
            return Ok("Auth ok");
        }
    }
}
