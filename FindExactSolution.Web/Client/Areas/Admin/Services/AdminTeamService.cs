using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Results;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Teams;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Services
{
    public class AdminTeamService : IAdminTeamService
    {
        private readonly HttpClient _httpClient;
        private const string BaseTeamsApiUrl = "admin/api/teams";

        public AdminTeamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AdminTeamEventResource>> GenerateTeamsAsync(AdminGenerateTeamResource resource)
        {
            var resourceJson = new StringContent(JsonConvert.SerializeObject(resource), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{BaseTeamsApiUrl}/{resource.EventId}", resourceJson);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<AdminTeamEventResource>>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }
    }
}