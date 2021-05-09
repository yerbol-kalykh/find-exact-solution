using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Results;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Services
{
    public class ResultService : IResultService
    {
        private readonly HttpClient _httpClient;
        private const string BaseLeaderboardApiUrl = "api/events/{0}/results/leaderboard";

        public ResultService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LeaderboardResource> GetLeaderboardAsync(Guid eventId)
        {
            return await _httpClient.GetFromJsonAsync<LeaderboardResource>($"{string.Format(BaseLeaderboardApiUrl, eventId)}");
        }
    }
}