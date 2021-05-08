using System.Collections.Generic;

namespace FindExactSolution.Application.Challenges.Models
{
    public class ChallengesResult
    {
        public EventChallengeDto Event { get; set; }

        public IEnumerable<ChallengeDto> Challenges { get; set; } = new List<ChallengeDto>();
    }
}
