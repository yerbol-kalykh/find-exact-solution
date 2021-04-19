using FindExactSolution.Domain.Common;
using System;
using System.Collections.Generic;

namespace FindExactSolution.Domain.Entities
{
    public class Team
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IList<IUser> Users { get; set; } = new List<IUser>();

        public IList<Event> Events { get; set; } = new List<Event>();
    }
}