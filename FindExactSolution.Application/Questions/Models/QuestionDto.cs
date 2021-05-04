using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;

namespace FindExactSolution.Application.Questions.Models
{
    public class QuestionDto : IMapFrom<Question>
    {
        public Guid Id { get; set; }

        public int Order { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int Point { get; set; }
    }
}