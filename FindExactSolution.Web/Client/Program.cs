using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("FindExactSolution.Web.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            builder.Services.AddHttpClient<IEventDataService, EventDataService>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("FindExactSolution.Web.ServerAPI"));

            builder.Services.AddApiAuthorization();


            await builder.Build().RunAsync();
        }
    }
}