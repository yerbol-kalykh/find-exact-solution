using AutoMapper;
using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Pages.Questions
{
    public partial class EditQuestion
    {
        [Parameter]
        public Guid EventId { get; set; }

        [Parameter]
        public Guid ChallengeId { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        [Inject]
        public NavigationManager UriHelper { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public IAdminQuestionService AdminQuestionService { get; set; }

        public ElementReference DivEditorElement { get; set; }

        public AdminQuestionEditResource AdminQuestionEditResource { get; set; } = new AdminQuestionEditResource();


        protected override async Task OnInitializedAsync()
        {
            try
            {
                var questionDetails = await AdminQuestionService.GetQuestionDetailsAsync(ChallengeId, Id);

                if (questionDetails == null) UriHelper.NavigateTo($"/admin/events");
                else
                {
                    Mapper.Map(questionDetails, AdminQuestionEditResource);

                    await JSRuntime.InvokeAsync<object>("QuillFunctions.loadQuillHTMLContent", DivEditorElement, AdminQuestionEditResource.Description);
                }
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeAsync<string>("QuillFunctions.createQuill", DivEditorElement);
            }
        }

        protected async Task HandleValidSubmit()
        {
            AdminQuestionEditResource.Description = await JSRuntime.InvokeAsync<string>("QuillFunctions.getQuillHTML", DivEditorElement);

            await AdminQuestionService.UpdateQuestionAsync(AdminQuestionEditResource);

            UriHelper.NavigateTo($"/admin/events/{EventId}/challenges/{ChallengeId}");
        }

        public void Cancel()
        {
            UriHelper.NavigateTo($"/admin/events/{EventId}/challenges/{ChallengeId}");
        }
    }
}
