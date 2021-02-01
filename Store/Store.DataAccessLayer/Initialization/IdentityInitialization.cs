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
        public static async Task InitializeAdminAsync(UserManager<User> userManager, IConfiguration configuration)
        {
            //throw new NotImplementedException();
            if (!(await userManager.FindByEmailAsync(configuration["AdminData:AdminEmail"]) is null))
            {
                return;
            }

            User admin = new User
            {
                Email = configuration["AdminData:AdminEmail"],
                UserName = configuration["AdminData:AdminEmail"],
                EmailConfirmed = true
            };
            IdentityResult result = await userManager.CreateAsync(admin, configuration["AdminData:Password"]);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, Enums.UserRole.Admin.ToString());
            }
        }

        public static async Task InitialazeRolesAsync(RoleManager<IdentityRole<Guid>> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Enums.UserRole.Admin.ToString()))
            {
                var adminRole = new IdentityRole<Guid>
                {
                    Name = Enums.UserRole.Admin.ToString(),
                    NormalizedName = Enums.UserRole.Client.ToString().ToUpper()
                };
                await roleManager.CreateAsync(adminRole);
            }
            if (!await roleManager.RoleExistsAsync(Enums.UserRole.Client.ToString()))
            {
                var clientRole = new IdentityRole<Guid>
                {
                    Name = Enums.UserRole.Client.ToString(),
                    NormalizedName = Enums.UserRole.Client.ToString().ToUpper()
                };
                await roleManager.CreateAsync(clientRole);
            }
        }
    }
}
