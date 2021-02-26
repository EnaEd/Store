using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Shared.Config;
using Store.Shared.Config.Logger;
using Store.Shared.Config.Mail;

namespace Store.Presentation.Extensions
{
    public static class ConfigurationExtension
    {
        public static void ConfigureAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Logging>(configuration);
            services.Configure<RequestEmail>(configuration);
            services.Configure<AdminData>(configuration);
            services.Configure<AuthOptions>(configuration);
            services.Configure<Environments>(configuration);
            services.Configure<StripeConfig>(configuration);
        }
    }
}
