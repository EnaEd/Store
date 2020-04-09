using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Store.Presentation.Extensions;
using Store.Shared.Constants;
using Store.Shared.Extensions;
using System.IO;

namespace Store.Presentation
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            BusinessLogicLayer.Startup.Init(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("Logger");

            env.EnvironmentName = Configuration["Environments:Production"];

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler(Constanst.ERROR_ROUTE);
            }

            app.UseRouting();

            //custom handler with logger
            app.UseErrorHandler();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map(Constanst.ERROR_ROUTE, async context =>
                {
                    await context.Response.WriteAsync($"something went wrong please see log file\n");
                });
                endpoints.MapGet("/", async context =>
                {
                    var x = 0;
                    await context.Response.WriteAsync($"{10 / x}");
                });
            });
        }
    }
}
