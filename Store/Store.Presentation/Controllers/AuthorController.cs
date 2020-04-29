using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogicLayer.Interfaces;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorSevice;

        public AuthorController(IAuthorService authorSevice)
        {
            _authorSevice = authorSevice;
        }

        [HttpGet("getallauthors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            return Ok(await _authorSevice.GetAuthorsAsync());
        }
    }
}
