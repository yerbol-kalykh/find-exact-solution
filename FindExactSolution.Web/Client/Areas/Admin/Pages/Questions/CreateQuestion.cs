using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Pages.Questions
{
    public partial class CreateQuestion
    {
        [Parameter]
        public Guid EventId { get; set; }

        [Parameter]
        public Guid ChallengeId { get; set; }

        [Inject]
        public NavigationManager UriHelper { get; set; }

        [Inject]
        public IAdminQuestionService AdminQuestionService { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public ElementReference DivEditorElement { get; set; }

        public AdminQuestionCreateResource AdminQuestionCreateResource { get; set; } = new AdminQuestionCreateResource();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeAsync<string>("QuillFunctions.createQuill", DivEditorElement);
            }
        }

        protected override void OnInitialized()
        {
            AdminQuestionCreateResource.ChallengeId = ChallengeId;
        }

        protected async Task HandleValidSubmit()
        {
            AdminQuestionCreateResource.Description = await JSRuntime.InvokeAsync<string>("QuillFunctions.getQuillHTML", DivEditorElement);

            var createId = await AdminQuestionService.CreateQuestionAsync(AdminQuestionCreateResource);

            if (createId == Guid.Empty)
            {

            }
            else
            {
                NavigateToChallengeDetailsPage();
            }
        }

        public void Cancel()
        {
            NavigateToChallengeDetailsPage();
        }

        private void NavigateToChallengeDetailsPage()
        {
            UriHelper.NavigateTo($"/admin/events/{EventId}/challenges/{ChallengeId}");
        }
    }
}