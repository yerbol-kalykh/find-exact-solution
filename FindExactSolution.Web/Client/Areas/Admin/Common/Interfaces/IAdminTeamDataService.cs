using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Teams;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces
{
    public interface IAdminTeamDataService
    {
        Task GenerateTeamsAsync(GenerateTeamResource resource);
    }
}
