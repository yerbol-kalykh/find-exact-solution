using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Events;
using FindExactSolution.Web.Client.Common.Resources.Registrations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Pages.Events
{
    public partial class EventDetails
    {
        [Parameter]
        public Guid Id { get; set; }

        [Inject]
        public IEventDataService EventDataService { get; set; }

        [Inject]
        public IRegistrationDataService RegistrationDataService { get; set; }

        private EventDetailsResource _event;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _event = await EventDataService.GetEventByIdAsync(Id);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        public async Task RegisterAsync()
        {
            var registrationResource = new CreateRegistrationResource() { EventId = _event.Id };

            await RegistrationDataService.CreateRegistrationAsync(registrationResource);

            _event = await EventDataService.GetEventByIdAsync(Id);
        }
    }
}