using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.DataAccessLayer.Entities;
using Store.Shared.Enums;
using System;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Initialization
{
    public static class IdentityInitialization
    {
        public static async Task InitializeAdminAsync(this IServiceCollection services, IConfiguration configuration)
        {
            var userManager = services.BuildServiceProvider().GetRequiredService<UserManager<User>>();

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

        public static async Task InitialazeRolesAsync(this IServiceCollection services)
        {
            var roleManager = services.BuildServiceProvider().GetRequiredService<RoleManager<IdentityRole<Guid>>>();
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
