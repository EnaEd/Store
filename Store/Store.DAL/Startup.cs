using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Store.DAL
{
    public class Startup
    {
        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppContext.AppContext>(options =>
                options.UseSqlServer(connection));
        }
    }
}
