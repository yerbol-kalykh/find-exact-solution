using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Teams;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces
{
    public interface IAdminTeamService
    {
        Task GenerateTeamsAsync(AdminGenerateTeamResource resource);
    }
}
