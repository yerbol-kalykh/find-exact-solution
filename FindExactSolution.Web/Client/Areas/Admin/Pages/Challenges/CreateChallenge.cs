using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Challenges;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Pages.Challenges
{
    public partial class CreateChallenge
    {
        [Parameter]
        public Guid EventId { get; set; }

        [Inject]
        public NavigationManager UriHelper { get; set; }

        [Inject]
        public IAdminChallengeService AdminChallengeService { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public ElementReference DivEditorElement { get; set; }

        public AdminChallengeCreateResource AdminChallengeCreateResource { get; set; } = new AdminChallengeCreateResource();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeAsync<string>("QuillFunctions.createQuill", DivEditorElement);
            }
        }

        protected override void OnInitialized()
        {
            AdminChallengeCreateResource.EventId = EventId;
        }

        protected async Task HandleValidSubmit()
        {
            AdminChallengeCreateResource.Body = await JSRuntime.InvokeAsync<string>("QuillFunctions.getQuillHTML", DivEditorElement);

            var createId = await AdminChallengeService.CreateChallengeAsync(AdminChallengeCreateResource);

            if (createId == Guid.Empty)
            {

            }
            else
            {
                UriHelper.NavigateTo($"/admin/events/{EventId}/challenges/{createId}");
            }
        }

        public void Cancel()
        {
            UriHelper.NavigateTo($"/admin/events/{EventId}");
        }
    }
}