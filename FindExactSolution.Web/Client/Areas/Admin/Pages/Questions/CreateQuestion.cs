using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Questions;
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

        [Inject]
        public NavigationManager UriHelper { get; set; }

        [Inject]
        public IAdminQuestionService AdminQuestionService { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public ElementReference DivEditorElement { get; set; }

        public CreateQuestionResource CreateQuestionResource { get; set; } = new CreateQuestionResource();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeAsync<string>("QuillFunctions.createQuill", DivEditorElement);
            }
        }

        protected override void OnInitialized()
        {
            CreateQuestionResource.EventId = EventId;
        }

        protected async Task HandleValidSubmit()
        {
            CreateQuestionResource.Body = await JSRuntime.InvokeAsync<string>("QuillFunctions.getQuillHTML", DivEditorElement);

            var createId = await AdminQuestionService.CreateQuestionAsync(CreateQuestionResource);

            if(createId == Guid.Empty)
            {
               
            }
            else
            {
                UriHelper.NavigateTo($"/admin/events/{EventId}/questions/{createId}");
            }
        }

        public void Cancel()
        {
            UriHelper.NavigateTo($"/admin/events/{EventId}");
        }
    }
}