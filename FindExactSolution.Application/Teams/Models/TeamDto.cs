using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FindExactSolution.Application.Teams.Models
{
    public class TeamDto : IMapFrom<Team>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UserTeamDto> Users { get; set; } = new List<UserTeamDto>();
    }
}