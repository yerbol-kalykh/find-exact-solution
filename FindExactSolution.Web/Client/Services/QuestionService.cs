using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Questions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly HttpClient _httpClient;
        private const string BaseQuestionsApiUrl = "api/events/{0}/questions";

        public QuestionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<QuestionResource>> GetAllQuestionsAsync(Guid eventId)
        {
            return await _httpClient.GetFromJsonAsync<QuestionResource[]>($"{string.Format(BaseQuestionsApiUrl, eventId)}");
        }
    }
}
