using FindExactSolution.Web.Client.Common.Resources.QuestionSubmissions;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Common.Interfaces
{
    public interface IQuestionSubmissionService
    {
        Task<bool> SubmitAnswerToQuestionAsync(SubmitAnswerResource resource);
    }
}
