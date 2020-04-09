using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Store.DataAccessLayer.Entities;
using Store.Shared.Enums;
using System;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Initialization
{
    public class IdentityInitialization
    {
        public static async Task InitializeAdmin(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager,
            IConfiguration configuration)
        {
            if (!(await userManager.FindByEmailAsync(configuration["AdminData:AdminEmail"]) is null))
            {
                return;
            }

            User admin = new User();
            admin.Email = configuration["AdminData:AdminEmail"];
            admin.UserName = configuration["AdminData:AdminEmail"];
            IdentityResult result = await userManager.CreateAsync(admin, configuration["AdminData:Password"]);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, UserRole.Admin.ToString());
            }
        }
    }
}
