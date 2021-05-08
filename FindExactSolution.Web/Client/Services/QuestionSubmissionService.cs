using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.QuestionSubmissions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
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

        public async Task<QuestionSubmissionChallengeResource> SubmitAnswerToQuestionAsync(SubmitAnswerResource resource)
        {
            var resourceJson = new StringContent(JsonConvert.SerializeObject(resource), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(string.Format(BaseQuestionsApiUrl, resource.EventId, resource.QuestionId), resourceJson);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<QuestionSubmissionChallengeResource>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }
    }
}
