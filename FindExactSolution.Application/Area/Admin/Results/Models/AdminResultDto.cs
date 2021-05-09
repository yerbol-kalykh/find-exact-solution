using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;

namespace FindExactSolution.Application.Area.Admin.Results.Models
{
    public class AdminResultDto : IMapFrom<Result>
    {
        public Guid EventId { get; set; }

        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public int TotalPoints { get; set; }

        public int TotalQuestions { get; set; }

        public int TotalChallenges { get; set; }

        public int SolvedQuestions { get; set; }

        public int SolvedChallenges { get; set; }

        public static AdminResultDto Create(Guid eventId, Guid teamId, string teamName, int totalChallenges, int totalQuestions)
        {
            return new AdminResultDto
            {
                EventId = eventId,
                TeamId = teamId,
                TeamName = teamName,
                TotalChallenges = totalChallenges,
                TotalQuestions = totalQuestions
            };
        }
    }
}
