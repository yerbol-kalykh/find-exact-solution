using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions;
using FindExactSolution.Web.Client.Common.Resources.Questions;
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
        private const string BaseQuestionsApiUrl = "admin/api/events/{0}/questions";

        public AdminQuestionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AdminQuestionDetailsResource> GetQuestionDetailsAsync(Guid eventId, Guid id)
        {
            return await _httpClient.GetFromJsonAsync<AdminQuestionDetailsResource>($"{string.Format(BaseQuestionsApiUrl, eventId)}/{id}");
        }

        public async Task<Guid> CreateQuestionAsync(CreateQuestionResource resource)
        {
            var resourceJson = new StringContent(JsonSerializer.Serialize(resource), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(string.Format(BaseQuestionsApiUrl,resource.EventId), resourceJson);

            if(response.StatusCode == HttpStatusCode.OK)
            {
                return await JsonSerializer.DeserializeAsync<Guid>(await response.Content.ReadAsStreamAsync());
            }

            return Guid.Empty;
        }

        public async Task UpdateQuestionAsync(EditQuestionResource resource)
        {
            var resourceJson = new StringContent(JsonSerializer.Serialize(resource), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync($"{string.Format(BaseQuestionsApiUrl, resource.EventId)}/{resource.Id}", resourceJson);
        }
    }
}
