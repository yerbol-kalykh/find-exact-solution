using System.Collections.Generic;

namespace FindExactSolution.Web.Client.Common.Resources.Results
{
    public class LeaderboardResource
    {
        public IEnumerable<ResultLeaderboardResource> Results { get; set; } = new List<ResultLeaderboardResource>();
    }
}