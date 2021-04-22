using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Teams;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Services
{
    public class AdminTeamDataService : IAdminTeamDataService
    {
        private readonly HttpClient _httpClient;
        private const string BaseEventApiUrl = "admin/api/teams";

        public AdminTeamDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GenerateTeamsAsync(GenerateTeamResource teamResource)
        {
            var teamResourceJson = new StringContent(JsonSerializer.Serialize(teamResource), Encoding.UTF8, "application/json");
            
            await _httpClient.PostAsync($"{BaseEventApiUrl}/{teamResource.EventId}", teamResourceJson);
        }
    }
}
