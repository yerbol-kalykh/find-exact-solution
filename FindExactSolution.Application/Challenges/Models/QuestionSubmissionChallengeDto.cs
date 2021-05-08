using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;

namespace FindExactSolution.Application.Challenges.Models
{
    public class QuestionSubmissionChallengeDto : IMapFrom<QuestionSubmission>
    {
        public bool IsCorrect { get; set; }

        public int TotalAttempts { get; set; }

        public DateTime LastSubmittedDateTime { get; set; }

        public string TeamAnswer { get; set; }
    }
}