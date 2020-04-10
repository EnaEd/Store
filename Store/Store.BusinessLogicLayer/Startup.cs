using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.Services;

namespace Store.BusinessLogicLayer
{
    public class Startup
    {
        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            DataAccessLayer.Startup.Init(services, configuration);
            services.AddTransient<IAccountService, AccountService>();
        }
    }
}
