using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Challenges;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly HttpClient _httpClient;
        private const string BaseChallengesApiUrl = "api/events/{0}/challenges";

        public ChallengeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ChallengeResource>> GetAllChallengesAsync(Guid eventId)
        {
            return await _httpClient.GetFromJsonAsync<ChallengeResource[]>($"{string.Format(BaseChallengesApiUrl, eventId)}");
        }
    }
}
