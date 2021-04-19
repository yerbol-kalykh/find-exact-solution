using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;

namespace FindExactSolution.Application.Area.Admin.Events.Models
{
    public class EventDetailDto : IMapFrom<Event>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }
    }
}
