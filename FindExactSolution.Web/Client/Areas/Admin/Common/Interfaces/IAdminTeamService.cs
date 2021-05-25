using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Teams;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces
{
    public interface IAdminTeamService
    {
        Task<IEnumerable<AdminTeamEventResource>> GenerateTeamsAsync(AdminGenerateTeamResource resource);
    }
}
