using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;

namespace FindExactSolution.Application.Area.Admin.Questions.Models
{
    public class QuestionDetailsDto : IMapFrom<Question>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Point { get; set; }

        public QuestionEventDto Event{ get; set; }
    }
}
