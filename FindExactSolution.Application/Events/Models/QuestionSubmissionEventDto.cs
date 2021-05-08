using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;

namespace FindExactSolution.Application.Events.Models
{
    public class QuestionSubmissionEventDto : IMapFrom<QuestionSubmission>
    {
        public bool IsCorrect { get; set; }

        public int TotalAttempts { get; set; }

        public DateTime LastSubmittedDateTime { get; set; }

        public string TeamAnswer { get; set; }
    }
}
