using FindExactSolution.Web.Client.Common.Resources.Teams;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Common.Interfaces
{
    public interface ITeamService
    {
        Task<TeamResource> GetTeamByIdAsync(Guid id);
        Task EditTeamAsync(TeamEditResource resource);
    }
}