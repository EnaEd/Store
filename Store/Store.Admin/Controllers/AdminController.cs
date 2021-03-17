using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Models.Users;
using Store.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Admin.Controllers
{

    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IAuthorService _authorService;
        public AdminController(IAdminService adminService, IAuthorService authorService)
        {
            _adminService = adminService;
            _authorService = authorService;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<UserProfileModel> result = await _adminService.GetFilteredUserProfileModelsAsync();
            return View(result.ToList());
        }

        [HttpGet]
        [Authorize(Roles = Constant.AuthRoles.ADMIN_ROLE)]
        public async Task<IActionResult> Authors()
        {
            throw new NotImplementedException();
            //IEnumerable<AuthorModel> result = await _authorService.GetAuthorsAsync();
            //return View(result.ToList());
        }
    }
}
