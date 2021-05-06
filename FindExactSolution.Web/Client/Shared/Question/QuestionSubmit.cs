using AutoMapper;
using FindExactSolution.Web.Client.Common.Resources.Questions;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Shared.Question
{
    public partial class QuestionSubmit
    {
        [Parameter]
        public QuestionChallengeResource QuestionChallengeResource { get; set; }

        public QuestionSubmitResource QuestionSubmitResource { get; set; } = new QuestionSubmitResource();

        [Inject]
        public IMapper Mapper { get; set; }

        protected override void OnInitialized()
        {
            Mapper.Map(QuestionChallengeResource, QuestionSubmitResource);
        }

        protected async Task HandleValidSubmit()
        {
            
        }
    }
}
