using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Events;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Services
{
    public class AdminEventService : IAdminEventService
    {
        private readonly HttpClient _httpClient;
        private const string BaseEventApiUrl = "admin/api/events";

        public AdminEventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AdminEventResource>> GetAllEventsAsync()
        {
            return await _httpClient.GetFromJsonAsync<AdminEventResource[]>($"{BaseEventApiUrl}");
        }

        public async Task<AdminEventDetailResource> GetEventDetailAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<AdminEventDetailResource>($"{BaseEventApiUrl}/{id}");
        }
    }
}
