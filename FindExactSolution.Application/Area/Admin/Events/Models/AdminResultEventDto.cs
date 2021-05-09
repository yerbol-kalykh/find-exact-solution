using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Application.Common.Models;
using System;

namespace FindExactSolution.Application.Area.Admin.Events.Models
{
    public class AdminResultEventDto : IMapFrom<Result>
    {
        public string TeamName { get; set; }
        public Guid EventId { get; set; }

        public Guid TeamId { get; set; }

        public int TotalPoints { get; set; }

        public int TotalQuestions { get; set; }

        public int TotalChallenges { get; set; }

        public int SolvedQuestions { get; set; }

        public int SolvedChallenges { get; set; }
    }
}
