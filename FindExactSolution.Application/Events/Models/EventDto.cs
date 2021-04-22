﻿using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Entities;
using System;

namespace FindExactSolution.Application.Events.Models
{
    public class EventDto : IMapFrom<Event>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }
    }
}
