using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Questions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Pages.Questions
{
    public partial class EventQuestions
    {
        [Parameter]
        public Guid EventId { get; set; }

        [Inject]
        public IQuestionService QuestionService { get; set; }

        private IEnumerable<QuestionResource> _questions;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _questions = await QuestionService.GetAllQuestionsAsync(EventId);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}
