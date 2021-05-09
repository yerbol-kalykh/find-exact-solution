using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Services
{
    public class AdminResultService : IAdminResultService
    {
        private readonly HttpClient _httpClient;
        private const string BaseResultsApiUrl = "admin/api/events/{0}/results";

        public AdminResultService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AdminResultEventResource>> GenerateLeaderboardAsync(Guid eventId)
        {
            var response = await _httpClient.PostAsync($"{string.Format(BaseResultsApiUrl, eventId)}/leaderboard/generate", null);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<IEnumerable<AdminResultEventResource>>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }
    }
}
