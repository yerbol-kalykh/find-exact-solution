using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");

            builder.Services.RegisterService(builder.HostEnvironment);

            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("FindExactSolution.Web.ServerAPI"));

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}