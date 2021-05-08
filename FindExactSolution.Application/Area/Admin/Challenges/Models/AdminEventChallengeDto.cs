using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;

namespace FindExactSolution.Application.Area.Admin.Challenges.Models
{
    public class AdminEventChallengeDto : IMapFrom<Event>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}