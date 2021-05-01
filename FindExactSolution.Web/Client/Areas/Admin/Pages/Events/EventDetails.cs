﻿using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
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
        public IAdminEventService AdminEventService { get; set; }

        [Inject]
        public IAdminTeamService AdminTeamService { get; set; }

        [Inject]
        public NavigationManager UriHelper { get; set; }

        private AdminEventDetailResource _eventDetail;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _eventDetail = await AdminEventService.GetEventDetailAsync(Id);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        public async Task GenerateTeamAsync()
        {
            var generateTeamResource = new GenerateTeamResource() { EventId = _eventDetail.Id };

            await AdminTeamService.GenerateTeamsAsync(generateTeamResource);
        }

        public void NavigateToCreateQuestion()
        {
            UriHelper.NavigateTo($"/admin/events/{Id}/questions/create");
        }
    }
}
