using System;

namespace FindExactSolution.Application.Events.Models
{
    public class ResultEventDto
    {
        public Guid TeamId { get; set; }

        public string TeamName { get; set; }
        
        public int TotalPoints { get; set; }

        public int TotalQuestions { get; set; }

        public int TotalChallenges { get; set; }

        public int SolvedQuestions { get; set; }

        public int SolvedChallenges { get; set; }
    }
}
