using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Questions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private QuestionResource _currentQuestion;

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _questions = await QuestionService.GetAllQuestionsAsync(EventId);

                _currentQuestion = _questions.FirstOrDefault();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        private void ChangeQuestion(Guid id)
        {
            _currentQuestion = _questions.FirstOrDefault(q=>q.Id == id);
        }
    }
}