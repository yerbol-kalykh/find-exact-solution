using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Pages.Questions
{
    public partial class QuestionDetails
    {
        [Parameter]
        public Guid EventId { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        [Inject]
        public IAdminQuestionService AdminQuestionService { get; set; }

        [Inject]
        public NavigationManager UriHelper { get; set; }

        private AdminQuestionDetailsResource _questionDetails;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                _questionDetails = await AdminQuestionService.GetQuestionDetailsAsync(EventId, Id);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        public void NavigateToEditQuestion()
        {
            UriHelper.NavigateTo($"/admin/events/{EventId}/questions/{Id}/edit");
        }
    }
}
