using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Registrations;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Services
{
    public class RegistrationDataService : IRegistrationDataService
    {
        private readonly HttpClient _httpClient;
        private const string BaseEventApiUrl = "api/registrations";

        public RegistrationDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateRegistrationAsync(CreateRegistrationResource resource)
        {
            var resourceJson = new StringContent(JsonSerializer.Serialize(resource), Encoding.UTF8, "application/json");

            await _httpClient.PostAsync($"{BaseEventApiUrl}", resourceJson);
        }
    }
}
