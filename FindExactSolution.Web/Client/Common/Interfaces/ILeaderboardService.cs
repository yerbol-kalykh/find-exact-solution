using FindExactSolution.Web.Client.Common.Resources.Leaderboard;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Common.Interfaces
{
    public interface ILeaderboardService
    {
        Task<LeaderboardResource> GetLeaderboardAsync(Guid eventId);
    }
}