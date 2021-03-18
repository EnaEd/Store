using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Store.BusinessLogicLayer;
using Store.BusinessLogicLayer.Services;
using Store.DataAccessLayer.Entities;
using Store.Presentation.Extensions;
using Store.Shared.Extensions;
using System.Linq;

namespace Store.Presentation
{
    public class Startup
    {
        public UserManager<User> UserManager { get; set; }
        public RoleManager<IdentityRole> RoleManager { get; set; }
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.Init(Configuration);
            Stripe.StripeConfiguration.ApiKey = Configuration["StripeConfig:ApiSecretKey"];
            services.ConfigureAppSettings(Configuration);

            var tokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = Configuration["AuthOptions:Issuer"],
                ValidateAudience = true,
                ValidAudience = Configuration["AuthOptions:Audience"],
                ValidateLifetime = true,
                IssuerSigningKey = JWTService.GetSymmetricSecurityKey(Configuration["AuthOptions:Key"]),
                ValidateIssuerSigningKey = true
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = tokenValidationParameters;
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore API", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            //var logger = loggerFactory.CreateLogger("Logger");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            //custom handler with logger
            app.UseErrorHandler();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
