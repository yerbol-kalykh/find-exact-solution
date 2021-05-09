using System;

namespace FindExactSolution.Domain.Entities
{
    public class Leaderboard
    {
        public Guid EventId { get; set; }

        public Guid TeamId { get; set; }

        public int TotalPoints { get; set; }

        public int TotalQuestions { get; set; }

        public int TotalChallenges { get; set; }

        public int SolvedQuestions { get; set; }

        public int SolvedChallenges { get; set; }
    }
}
