using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Services
{
    public class AdminQuestionService : IAdminQuestionService
    {
        private readonly HttpClient _httpClient;
        private const string BaseQuestionsApiUrl = "admin/api/challenges/{0}/questions";

        public AdminQuestionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AdminQuestionDetailsResource> GetQuestionDetailsAsync(Guid challengeId, Guid id)
        {
            return await _httpClient.GetFromJsonAsync<AdminQuestionDetailsResource>($"{string.Format(BaseQuestionsApiUrl, challengeId)}/{id}");
        }

        public async Task<Guid> CreateQuestionAsync(AdminQuestionCreateResource resource)
        {
            var resourceJson = new StringContent(JsonSerializer.Serialize(resource), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(string.Format(BaseQuestionsApiUrl, resource.ChallengeId), resourceJson);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await JsonSerializer.DeserializeAsync<Guid>(await response.Content.ReadAsStreamAsync());
            }

            return Guid.Empty;
        }

        public async Task UpdateQuestionAsync(AdminQuestionEditResource resource)
        {
            var resourceJson = new StringContent(JsonSerializer.Serialize(resource), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync($"{string.Format(BaseQuestionsApiUrl, resource.ChallengeId)}/{resource.Id}", resourceJson);
        }
    }
}
