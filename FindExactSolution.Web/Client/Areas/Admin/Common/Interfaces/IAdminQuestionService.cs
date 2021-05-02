using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions;
using FindExactSolution.Web.Client.Common.Resources.Questions;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces
{
    public interface IAdminQuestionService
    {
        Task<AdminQuestionDetailsResource> GetQuestionDetailsAsync(Guid eventId, Guid id);

        Task<Guid> CreateQuestionAsync(CreateQuestionResource resource);

        Task UpdateQuestionAsync(EditQuestionResource resource);
    }
}
