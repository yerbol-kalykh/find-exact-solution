using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Teams;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Components.Team
{
    public partial class EditTeamDialog
    {
        public bool ShowDialog { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Inject]
        public ITeamService TeamService { get; set; }

        public TeamEditResource TeamEditResource { get; set; } = new TeamEditResource();

        protected override void OnInitialized()
        {
            TeamEditResource.Id = Id;
            TeamEditResource.Name = Name;
        }

        public void Show()
        {
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            await TeamService.EditTeamAsync(TeamEditResource);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}
