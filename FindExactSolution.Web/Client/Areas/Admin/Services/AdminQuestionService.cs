using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Questions;
using System.Net.Http;
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

        public async Task CreateQuestionAsync(CreateQuestionResource resource)
        {
            var resourceJson = new StringContent(JsonSerializer.Serialize(resource), Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(string.Format(BaseQuestionsApiUrl,resource.EventId), resourceJson);
        }
    }
}
