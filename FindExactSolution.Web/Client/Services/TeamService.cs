using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Teams;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Services
{
    public class TeamService : ITeamService
    {
        private readonly HttpClient _httpClient;
        private const string BaseTeamApiUrl = "api/teams";

        public TeamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task EditTeamAsync(TeamEditResource resource)
        {
            var resourceJson = new StringContent(JsonConvert.SerializeObject(resource), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync($"{BaseTeamApiUrl}/{resource.Id}", resourceJson);
        }

        public async Task<TeamResource> GetTeamByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<TeamResource>($"{BaseTeamApiUrl}/{id}");
        }
    }
}
