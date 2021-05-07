using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.QuestionSubmissions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Services
{
    public class QuestionSubmissionService : IQuestionSubmissionService
    {
        private readonly HttpClient _httpClient;
        private const string BaseQuestionsApiUrl = "api/events/{0}/questions/{1}/questionSubmissions";

        public QuestionSubmissionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> SubmitAnswerToQuestionAsync(SubmitAnswerResource resource)
        {
            var resourceJson = new StringContent(JsonSerializer.Serialize(resource), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(string.Format(BaseQuestionsApiUrl, resource.EventId, resource.QuestionId), resourceJson);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await JsonSerializer.DeserializeAsync<bool>(await response.Content.ReadAsStreamAsync());
            }

            return false;
        }
    }
}
