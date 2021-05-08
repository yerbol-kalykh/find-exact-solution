using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;

namespace FindExactSolution.Application.Challenges.Models
{
    public class QuestionChallengeDto
    {
        public Guid Id { get; set; }

        public Guid ChallengeId { get; set; }

        public string Description { get; set; }
        public string Input { get; set; }
        public int Point { get; set; }

        public QuestionSubmissionChallengeDto QuestionSubmission { get; set; } = new QuestionSubmissionChallengeDto();
    }
}
