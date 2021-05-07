using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Questions;
using FindExactSolution.Web.Client.Common.Resources.QuestionSubmissions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Shared.Question
{
    public partial class QuestionSubmit
    {
        [Parameter]
        public QuestionChallengeResource QuestionChallengeResource { get; set; }

        [Parameter]
        public Guid EventId { get; set; }

        [Inject]
        public IQuestionSubmissionService QuestionSubmissionService { get; set; }

        public SubmitAnswerResource SubmitAnswerResource { get; set; } = new SubmitAnswerResource();

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;

        protected override void OnInitialized()
        {
            SubmitAnswerResource.EventId = EventId;
            SubmitAnswerResource.QuestionId = QuestionChallengeResource.Id;
        }

        protected async Task HandleValidSubmit()
        {
            var isCorrect = await QuestionSubmissionService.SubmitAnswerToQuestionAsync(SubmitAnswerResource);

            if (isCorrect)
            {
                StatusClass = "alert-success";
                Message = "That is the correct answer.";
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "That is incorrect answer.";
            }
        }

        protected async Task DownloadInput()
        {
            await JSRuntime.InvokeAsync<object>("FileSaveAs", $"{Guid.NewGuid()}.txt", QuestionChallengeResource.Input);
        }
    }
}
