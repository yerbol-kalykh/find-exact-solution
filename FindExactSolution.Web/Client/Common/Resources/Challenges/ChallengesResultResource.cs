using FindExactSolution.Web.Client.Common.Resources.Events;
using System.Collections.Generic;

namespace FindExactSolution.Web.Client.Common.Resources.Challenges
{
    public class ChallengesResultResource
    {
        public EventResource Event { get; set; }
        public IEnumerable<ChallengeResource> Challenges { get; set; }
    }
}
