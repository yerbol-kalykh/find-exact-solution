using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;

namespace FindExactSolution.Application.Area.Admin.Questions.Models
{
    public class QuestionDetailsDto : IMapFrom<Question>
    {
        public Guid Id { get; set; }
        public Guid ChallengeId { get; set; }
        public string Description { get; set; }
        public string Input { get; set; }
        public string Answer { get; set; }
        public int Point { get; set; }
    }
}
