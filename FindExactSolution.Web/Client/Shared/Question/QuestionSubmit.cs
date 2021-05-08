using AutoMapper;
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
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;

        [Parameter]
        public QuestionChallengeResource QuestionChallengeResource { get; set; }

        [Parameter]
        public Guid EventId { get; set; }

        [Inject]
        public IQuestionSubmissionService QuestionSubmissionService { get; set; }

        public SubmitAnswerResource SubmitAnswerResource { get; set; } = new SubmitAnswerResource();

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        protected override void OnInitialized()
        {
            SubmitAnswerResource.EventId = EventId;
            Mapper.Map(QuestionChallengeResource, SubmitAnswerResource);
        }

        protected async Task HandleValidSubmit()
        {
            QuestionChallengeResource.QuestionSubmission = await QuestionSubmissionService.SubmitAnswerToQuestionAsync(SubmitAnswerResource);

            if (QuestionChallengeResource.QuestionSubmission != null)
            {
                if (QuestionChallengeResource.IsSolved)
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
        }

        protected async Task DownloadInput()
        {
            await JSRuntime.InvokeAsync<object>("FileSaveAs", $"{Guid.NewGuid()}.txt", QuestionChallengeResource.Input);
        }
    }
}
