using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Author;
using Store.Shared.Constants;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Presentation.Controllers
{
    [Route(Constant.Routes.DEFAULT_API_ROUTE)]
    [Authorize(Roles = Constant.AuthRoles.ADMIN_ROLE)]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorSevice;

        public AuthorController(IAuthorService authorSevice)
        {
            _authorSevice = authorSevice;
        }

        [HttpGet(Constant.Routes.GET_AUTHORS_ROUTE)]
        public async Task<IActionResult> GetAllAuthors()
        {
            return Ok(await _authorSevice.GetAuthorsAsync());
        }

        [HttpPost(Constant.Routes.CREATE_AUTHOR_ROUTE)]
        public async Task<IActionResult> CreateAuthor([FromBody]AuthorModel model)
        {
            await _authorSevice.CreateAuthorAsync(model);
            return Ok(Constant.Info.CREATE_AUTHOR_SUCCESS);
        }

        [HttpPost(Constant.Routes.GET_AUTHOR_ROUTE)]
        public async Task<IActionResult> GetAuthor([FromBody]AuthorModel model)
        {
            return Ok(await _authorSevice.GetOneAuthorAsync(model));
        }

        [HttpPost(Constant.Routes.DELETE_AUTHOR_ROUTE)]
        public async Task<IActionResult> DeleteAuthor([FromBody]AuthorModel model)
        {
            await _authorSevice.RemoveAuthorAsync(model);
            return Ok(Constant.Info.DELETE_AUTHOR_SUCCESS);
        }

        [HttpPost(Constant.Routes.UPDATE_AUTHOR_ROUTE)]
        public async Task<IActionResult> UpdateAuthor([FromBody]AuthorModel model)
        {
            await _authorSevice.UpdateAuthorAsync(model);
            return Ok(Constant.Info.UPDATE_AUTHOR_SUCCESS);
        }
    }
}
