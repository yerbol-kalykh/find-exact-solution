using FindExactSolution.Domain.Common;
using FindExactSolution.Domain.Enums;
using System;

namespace FindExactSolution.Domain.Entities
{
    public class Registration
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public IUser User { get; set; }

        public Guid EventId { get; set; }

        public Event Event { get; set; }

        public RegistrationStatus Status { get; set; }
    }
}
