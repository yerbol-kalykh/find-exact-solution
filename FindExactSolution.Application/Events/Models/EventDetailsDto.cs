using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;

namespace FindExactSolution.Application.Events.Models
{
    public class EventDetailsDto : IMapFrom<Event>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public bool IsCurrentUserRegistered { get; set; }
    }
}