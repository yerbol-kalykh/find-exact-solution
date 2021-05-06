using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Challenges;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces
{
    public interface IAdminChallengeService
    {
        Task<AdminChallengeDetailsResource> GetChallengeDetailsAsync(Guid eventId, Guid id);

        Task<Guid> CreateChallengeAsync(AdminChallengeCreateResource resource);

        Task UpdateChallengeAsync(AdminChallengeEditResource resource);
    }
}
