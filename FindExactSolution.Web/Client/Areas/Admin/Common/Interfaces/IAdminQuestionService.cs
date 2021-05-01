using FindExactSolution.Web.Client.Common.Resources.Questions;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces
{
    public interface IAdminQuestionService
    {
        Task CreateQuestionAsync(CreateQuestionResource resource);
    }
}
