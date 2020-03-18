using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Store.BusinessLogicLayer
{
    public class Startup
    {
        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            DataAccessLayer.Startup.Init(services, configuration);
        }
    }
}
