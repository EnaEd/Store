using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.DataAccessLayer.AppContext;
using Store.DataAccessLayer.Entities;
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

        }
    }
}
