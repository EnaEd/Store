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
                //var adminRole = await userManager.GetRolesAsync(
                //    await userManager.FindByEmailAsync(configuration["AdminData:AdminEmail"]));
                //if (adminRole.Count == default(int))
                //{
                //    await userManager.AddToRoleAsync(await userManager.FindByEmailAsync(configuration["AdminData:AdminEmail"]), UserRole.Admin.ToString());
                //}
                return;
            }

            User admin = new User();
            admin.Email = configuration["AdminData:AdminEmail"];
            admin.UserName = configuration["AdminData:AdminEmail"];
            admin.EmailConfirmed = true;
            //admin.RefreshToken = null;
            IdentityResult result = await userManager.CreateAsync(admin, configuration["AdminData:Password"]);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, UserRole.Admin.ToString());
            }
        }

        public static async Task InitialazeRoles(RoleManager<IdentityRole<Guid>> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(UserRole.Admin.ToString()))
            {
                var adminRole = new IdentityRole<Guid>
                {
                    Name = UserRole.Admin.ToString(),
                    NormalizedName = UserRole.Client.ToString().ToUpper()
                };
                await roleManager.CreateAsync(adminRole);
            }
            if (!await roleManager.RoleExistsAsync(UserRole.Client.ToString()))
            {
                var clientRole = new IdentityRole<Guid>
                {
                    Name = UserRole.Client.ToString(),
                    NormalizedName = UserRole.Client.ToString().ToUpper()
                };
                await roleManager.CreateAsync(clientRole);
            }
        }
    }
}
