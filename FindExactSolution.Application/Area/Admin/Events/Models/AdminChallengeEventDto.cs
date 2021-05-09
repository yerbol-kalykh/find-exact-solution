using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;

namespace FindExactSolution.Application.Area.Admin.Events.Models
{
    public class AdminChallengeEventDto : IMapFrom<Challenge>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public int Point { get; set; }
    }
}
