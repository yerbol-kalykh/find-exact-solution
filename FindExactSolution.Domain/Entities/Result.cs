using System;

namespace FindExactSolution.Domain.Entities
{
    public class Result
    {
        public Guid EventId { get; set; }
        public Event Event { get; set; }

        public Guid TeamId { get; set; }

        public Team Team { get; set; }

        public int TotalPoints { get; set; }

        public int TotalQuestions { get; set; }

        public int TotalChallenges { get; set; }

        public int SolvedQuestions { get; set; }

        public int SolvedChallenges { get; set; }
    }
}
