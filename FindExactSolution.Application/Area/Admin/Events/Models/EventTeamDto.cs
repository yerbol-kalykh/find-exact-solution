using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;

namespace FindExactSolution.Application.Area.Admin.Events.Models
{
    public class EventTeamDto : IMapFrom<Team>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}