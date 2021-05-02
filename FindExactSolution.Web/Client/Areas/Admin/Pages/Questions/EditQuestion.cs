using AutoMapper;
using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Questions;
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
        public Guid Id { get; set; }

        [Inject]
        public IAdminEventService AdminEventService { get; set; }

        [Inject]
        public IAdminQuestionService AdminQuestionService { get; set; }

        [Inject]
        public NavigationManager UriHelper { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public IMapper Mapper { get; set; } 

        public ElementReference DivEditorElement { get; set; }

        public EditQuestionResource EditQuestionResource { get; set; } = new EditQuestionResource();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var questionDetail = await AdminQuestionService.GetQuestionDetailsAsync(EventId, Id);

                if (questionDetail == null) UriHelper.NavigateTo($"/admin/events");
                else
                {
                    Mapper.Map(questionDetail,EditQuestionResource);

                    await JSRuntime.InvokeAsync<object>("QuillFunctions.loadQuillHTMLContent", DivEditorElement, questionDetail.Body);
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
            EditQuestionResource.Body = await JSRuntime.InvokeAsync<string>("QuillFunctions.getQuillHTML", DivEditorElement);

            await AdminQuestionService.UpdateQuestionAsync(EditQuestionResource);

            UriHelper.NavigateTo($"/admin/events/{EventId}/questions/{Id}");
        }

        public void Cancel()
        {
            UriHelper.NavigateTo($"/admin/events/{EventId}");
        }
    }
}
