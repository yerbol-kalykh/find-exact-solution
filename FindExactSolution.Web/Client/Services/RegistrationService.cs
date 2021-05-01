﻿using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Registrations;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly HttpClient _httpClient;
        private const string BaseRegistrationsApiUrl = "api/registrations";

        public RegistrationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateRegistrationAsync(CreateRegistrationResource resource)
        {
            var resourceJson = new StringContent(JsonSerializer.Serialize(resource), Encoding.UTF8, "application/json");

            await _httpClient.PostAsync($"{BaseRegistrationsApiUrl}", resourceJson);
        }
    }
}
