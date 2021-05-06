using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces
{
    public interface IAdminQuestionService
    {
        Task<AdminQuestionDetailsResource> GetQuestionDetailsAsync(Guid challengeId, Guid id);

        Task<Guid> CreateQuestionAsync(AdminQuestionCreateResource resource);

        Task UpdateQuestionAsync(AdminQuestionEditResource resource);
    }
}
