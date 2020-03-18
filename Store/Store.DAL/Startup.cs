
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.DAL.Entities;

namespace Store.DAL
{
    public class Startup
    {
        public static void Init(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AppContext.AppContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentityCore<Users>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppContext.AppContext>();
        }
    }
}
