using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FindExactSolution.Application.Area.Admin.Challenges.Models
{
    public class AdminChallengeDetailsDto : IMapFrom<Challenge>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public AdminEventChallengeDto Event { get; set; }
        public IEnumerable<AdminQuestionChallengeDto> Questions { get; set; } = new List<AdminQuestionChallengeDto>();
    }
}