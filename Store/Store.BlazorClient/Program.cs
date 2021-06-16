using Blazored.LocalStorage;
using BlazorFluentUI;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Store.BlazorClient.Services;
using Store.BlazorClient.Services.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Store.BlazorClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBlazorFluentUI();

            builder.Services.AddScoped<StateContainer>();

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, StoreAuthStateProvider>();
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
