using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Events;
using FindExactSolution.Web.Client.Common.Resources.Registrations;
using FindExactSolution.Web.Client.Components.Team;
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
        public IEventService EventService { get; set; }

        [Inject]
        public IRegistrationService RegistrationService { get; set; }

        [Inject]
        public ITeamService TeamService { get; set; }

        private EventDetailsResource _event;

        protected EditTeamDialog EditTeamDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _event = await EventService.GetEventByIdAsync(Id);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        public async Task RegisterAsync()
        {
            var registrationResource = new CreateRegistrationResource() { EventId = _event.Id };

            await RegistrationService.CreateRegistrationAsync(registrationResource);

            _event = await EventService.GetEventByIdAsync(Id);
        }

        protected void ShowEditTeamDialog()
        {
            EditTeamDialog.Show();
        }

        public async void EditTeamDialog_OnDialogClose()
        {
            _event.Team = await TeamService.GetTeamByIdAsync(_event.Team.Id);
            StateHasChanged();
        }
    }
}