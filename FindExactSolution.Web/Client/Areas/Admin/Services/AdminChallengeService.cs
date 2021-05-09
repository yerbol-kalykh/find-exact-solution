using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Challenges;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Services
{
    public class AdminChallengeService : IAdminChallengeService
    {
        private readonly HttpClient _httpClient;
        private const string BaseChallengesApiUrl = "admin/api/events/{0}/challenges";

        public AdminChallengeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AdminChallengeDetailsResource> GetChallengeDetailsAsync(Guid eventId, Guid id)
        {
            return await _httpClient.GetFromJsonAsync<AdminChallengeDetailsResource>($"{string.Format(BaseChallengesApiUrl, eventId)}/{id}");
        }

        public async Task<Guid> CreateChallengeAsync(AdminChallengeCreateResource resource)
        {
            var resourceJson = new StringContent(JsonConvert.SerializeObject(resource), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(string.Format(BaseChallengesApiUrl, resource.EventId), resourceJson);

            if(response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<Guid>(await response.Content.ReadAsStringAsync());
            }

            return Guid.Empty;
        }

        public async Task UpdateChallengeAsync(AdminChallengeEditResource resource)
        {
            var resourceJson = new StringContent(JsonConvert.SerializeObject(resource), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync($"{string.Format(BaseChallengesApiUrl, resource.EventId)}/{resource.Id}", resourceJson);
        }
    }
}
