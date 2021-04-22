using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Events;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Teams;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Pages.Events
{
    public partial class EventDetails
    {
        [Parameter]
        public Guid Id { get; set; }

        [Inject]
        public IAdminEventDataService AdminEventDataService { get; set; }

        [Inject]
        public IAdminTeamDataService AdminTeamDataService { get; set; }

        private AdminEventDetailResource _eventDetail;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _eventDetail = await AdminEventDataService.GetEventDetailAsync(Id);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        public async Task GenerateTeamAsync()
        {
            var generateTeamResource = new GenerateTeamResource() { EventId = _eventDetail.Id };

            await AdminTeamDataService.GenerateTeamsAsync(generateTeamResource);
        }
    }
}
