using System;
using System.Collections.Generic;

namespace FindExactSolution.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }

        public DateTime Date { get; set; }

        public DateTime? DeleteDate { get; set; }

        public IList<Question> Questions { get; set; } = new List<Question>();

        public IList<Team> Teams { get; set; } = new List<Team>();

        public IList<Registration> Registrations { get; set; } = new List<Registration>();
    }
}