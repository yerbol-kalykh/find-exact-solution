using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;

namespace FindExactSolution.Application.Area.Admin.Challenges.Models
{
    public class QuestionChallengeDto : IMapFrom<Question>
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Input { get; set; }

        public string Answer { get; set; }

        public int Point { get; set; }
    }
}
