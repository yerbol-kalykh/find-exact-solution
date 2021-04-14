using System;
using System.Collections.Generic;

namespace FindExactSolution.Domain.Entities
{
    public class Question
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Point { get; set; }

        public IList<Event> Events { get; set; } = new List<Event>();
    }
}