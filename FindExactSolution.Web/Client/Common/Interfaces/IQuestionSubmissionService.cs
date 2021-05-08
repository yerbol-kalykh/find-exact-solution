using FindExactSolution.Web.Client.Common.Resources.Questions;
using FindExactSolution.Web.Client.Common.Resources.QuestionSubmissions;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Common.Interfaces
{
    public interface IQuestionSubmissionService
    {
        Task<QuestionSubmissionChallengeResource> SubmitAnswerToQuestionAsync(SubmitAnswerResource resource);
    }
}
