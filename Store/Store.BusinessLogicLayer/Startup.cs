using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.BusinessLogicLayer.Interfaces;
using Store.BusinessLogicLayer.MappingProfiles;
using Store.BusinessLogicLayer.Services;

namespace Store.BusinessLogicLayer
{
    public class Startup
    {
        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            DataAccessLayer.Startup.Init(services, configuration);

            var mapperConfig = new MapperConfiguration(config =>
              {
                  config.AddProfile(new UserMappingProfile());
                  config.AddProfile(new AuthorMappingProfile());
                  config.AddProfile(new PrintingEditionProfile());
              });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IJWTService, JWTService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IPrintingEditionService, PrintingEditionService>();
            services.AddTransient<IAuthorInPintingEditionService, AuthorInPintingEditionService>();
        }
    }
}
