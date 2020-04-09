using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Initialization;
using System;

namespace Store.DataAccessLayer
{
    public class Startup
    {
        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                optionsBuilder => optionsBuilder.MigrationsAssembly("Store.DataAccessLayer")));

            services.AddIdentityCore<User>()
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationContext>();

            ServiceProvider provider = services.BuildServiceProvider();
            var userManager = provider.GetRequiredService<UserManager<User>>();
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            IdentityInitialization.InitializeAdmin(userManager, roleManager, configuration).Wait();

        }
    }
}
