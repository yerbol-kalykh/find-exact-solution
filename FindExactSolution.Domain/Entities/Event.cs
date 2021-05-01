using System;
using System.Collections.Generic;

namespace FindExactSolution.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool IsActive { get; set; }

        public IList<Question> Questions { get; set; } = new List<Question>();

        public IList<Team> Teams { get; set; } = new List<Team>();

        public IList<Registration> Registrations { get; set; } = new List<Registration>();
    }
}