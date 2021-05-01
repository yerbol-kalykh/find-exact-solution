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
        private ElementReference _divEditorElement;

        [Parameter]
        public Guid EventId { get; set; }

        public CreateQuestionResource CreateQuestionResource { get; set; } = new CreateQuestionResource();

        [Inject]
        public NavigationManager UriHelper { get; set; }

        [Inject]
        public IAdminQuestionService AdminQuestionService { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeAsync<string>("QuillFunctions.createQuill", _divEditorElement);
            }
        }

        protected override void OnInitialized()
        {
            CreateQuestionResource.EventId = EventId;
        }

        protected async Task HandleValidSubmit()
        {
            CreateQuestionResource.Body = await JSRuntime.InvokeAsync<string>("QuillFunctions.getQuillHTML", _divEditorElement);

            await AdminQuestionService.CreateQuestionAsync(CreateQuestionResource);
        }

        public void Cancel()
        {
            UriHelper.NavigateTo($"/admin/events/{EventId}");
        }
    }
}