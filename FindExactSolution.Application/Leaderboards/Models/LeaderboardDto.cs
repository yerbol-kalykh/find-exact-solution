using System.Collections.Generic;

namespace FindExactSolution.Application.Leaderboards.Models
{
    public class LeaderboardDto
    {
        public IEnumerable<ResultLeaderboardDto> Results { get; set; } = new List<ResultLeaderboardDto>();
    }
}
