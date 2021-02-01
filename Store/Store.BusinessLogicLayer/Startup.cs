using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Scrutor;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.MappingProfiles;
using Store.BusinessLogicLayer.Models.Config;


namespace Store.BusinessLogicLayer
{
    public static class Startup
    {
        public static void Init(this IServiceCollection services, IConfiguration configuration)
        {
            DataAccessLayer.Startup.Init(services, configuration);
            services.Configure<StripeConfig>(configuration.GetSection("StripeConfig"));
            IOptions<StripeConfig> stripeConfig = services.BuildServiceProvider().GetService<IOptions<StripeConfig>>();
            Stripe.StripeConfiguration.ApiKey = stripeConfig.Value.ApiSecretKey;

            var mapperConfig = new MapperConfiguration(config =>
              {
                  config.AddProfile(new UserMappingProfile());
                  config.AddProfile(new AuthorMappingProfile());
                  config.AddProfile(new PrintingEditionProfile());
              });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.Scan(scan => scan
            .FromAssemblyOf<IEmailService>()
            .AddClasses()
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithTransientLifetime());
        }
    }
}
