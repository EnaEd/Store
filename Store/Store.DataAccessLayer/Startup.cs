using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Initialization;
using Store.DataAccessLayer.Repositories;
using Store.DataAccessLayer.Repositories.Interfaces;
using System;

namespace Store.DataAccessLayer
{
    public class Startup
    {
        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            //TODO EE: get new connection string with sql auth
            services.AddDbContext<ApplicationContext>(option =>
                      option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                          optionsBuilder => optionsBuilder.MigrationsAssembly("Store.DataAccessLayer")));


            services.AddIdentityCore<User>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddSignInManager()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddAuthentication().AddIdentityCookies();


            //services.AddScoped<SignInManager<User>, SignInManager<User>>();
            services.AddTransient<IUserRepository<User>, UserRepository>();


            ServiceProvider provider = services.BuildServiceProvider();
            UserManager<User> userManager = provider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole<Guid>> roleManager = provider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            IdentityInitialization.InitialazeRoles(roleManager).Wait();
            IdentityInitialization.InitializeAdmin(userManager, roleManager, configuration).Wait();

        }
    }
}
