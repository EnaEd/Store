using Microsoft.AspNetCore.Identity;
using Store.DataAccessLayer.Entities;
using System;

namespace Store.DataAccessLayer.Initialization
{
    public class IdentityInitialization
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        public IdentityInitialization(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
    }
}
