using System;
using System.Collections.Generic;

namespace FindExactSolution.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public IList<Question> Questions { get; set; } = new List<Question>();
    }
}