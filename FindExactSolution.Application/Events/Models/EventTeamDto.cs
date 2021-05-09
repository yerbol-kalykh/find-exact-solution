using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FindExactSolution.Application.Events.Models
{
    public class EventTeamDto : IMapFrom<Team>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UserEventDto> Users { get; set; } = new List<UserEventDto>();
    }
}