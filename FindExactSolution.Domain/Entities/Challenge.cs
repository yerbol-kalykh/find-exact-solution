using System;
using System.Collections.Generic;

namespace FindExactSolution.Domain.Entities
{
    public class Challenge
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int Order { get; set; }

        public Guid EventId { get; set; }

        public Event Event { get; set; }

        public IList<Question> Questions { get; set; } = new List<Question>();
    }
}