using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Services;
using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FindExactSolution.Web.Client
{
    public static class ServiceInjection
    {
        public static IServiceCollection RegisterService(this IServiceCollection services, IWebAssemblyHostEnvironment hostEnvironment)
        {
            services.AddHttpClient<IEventService, EventService>(client => client.BaseAddress = new Uri(hostEnvironment.BaseAddress))
                          .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            services.AddHttpClient<IRegistrationService, RegistrationService>(client => client.BaseAddress = new Uri(hostEnvironment.BaseAddress))
                       .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            services.AddHttpClient<IChallengeService, ChallengeService>(client => client.BaseAddress = new Uri(hostEnvironment.BaseAddress))
                       .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            services.AddHttpClient<IQuestionSubmissionService, QuestionSubmissionService>(client => client.BaseAddress = new Uri(hostEnvironment.BaseAddress))
                      .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();


            services.AddHttpClient<IAdminEventService, AdminEventService>(client => client.BaseAddress = new Uri(hostEnvironment.BaseAddress))
               .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            services.AddHttpClient<IAdminTeamService, AdminTeamService>(client => client.BaseAddress = new Uri(hostEnvironment.BaseAddress))
                           .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            services.AddHttpClient<IAdminChallengeService, AdminChallengeService>(client => client.BaseAddress = new Uri(hostEnvironment.BaseAddress))
                           .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            services.AddHttpClient<IAdminQuestionService, AdminQuestionService>(client => client.BaseAddress = new Uri(hostEnvironment.BaseAddress))
                          .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            return services;
        }
    }
}
