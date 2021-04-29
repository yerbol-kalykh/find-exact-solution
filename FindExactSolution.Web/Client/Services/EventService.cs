using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Events;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Services
{
    public class EventService : IEventService
    {
        private readonly HttpClient _httpClient;
        private const string BaseEventApiUrl = "api/events";

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<EventResource>> GetAllEventsAsync()
        {
            return await _httpClient.GetFromJsonAsync<EventResource[]>($"{BaseEventApiUrl}");
        }

        public async Task<EventDetailsResource> GetEventByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<EventDetailsResource>($"{BaseEventApiUrl}/{id}");
        }
    }
}