using System;
using System.Collections.Generic;

namespace FindExactSolution.Application.Challenges.Models
{
    public class ChallengeDto 
    {
        public Guid Id { get; set; }

        public int Order { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int Point { get; set; }

        public IEnumerable<QuestionChallengeDto> Questions { get; set; } = new List<QuestionChallengeDto>();
    }
}