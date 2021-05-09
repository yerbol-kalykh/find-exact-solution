using FindExactSolution.Web.Client.Common.Resources.Results;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Common.Interfaces
{
    public interface IResultService
    {
        Task<LeaderboardResource> GetLeaderboardAsync(Guid eventId);
    }
}