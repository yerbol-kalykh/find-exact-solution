using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FindExactSolution.Application.Area.Admin.Events.Models
{
    public class EventDetailDto : IMapFrom<Event>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public IEnumerable<EventTeamDto> Teams { get; set; }

        public IEnumerable<EventRegistrationDto> Registrations { get; set; }

        public IEnumerable<EventQuestionDto> Questions { get; set; }
    }
}
