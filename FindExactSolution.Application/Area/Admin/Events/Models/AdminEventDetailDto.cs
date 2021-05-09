using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FindExactSolution.Application.Area.Admin.Events.Models
{
    public class AdminEventDetailDto : IMapFrom<Event>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public bool IsOpen { get; set; }

        public IEnumerable<AdminTeamEventDto> Teams { get; set; } = new List<AdminTeamEventDto>();

        public IEnumerable<AdminRegistrationEventDto> Registrations { get; set; } = new List<AdminRegistrationEventDto>();

        public IEnumerable<AdminChallengeEventDto> Challenges { get; set; } = new List<AdminChallengeEventDto>();

        public IEnumerable<AdminResultEventDto> Results { get; set; } = new List<AdminResultEventDto>();
    }
}
