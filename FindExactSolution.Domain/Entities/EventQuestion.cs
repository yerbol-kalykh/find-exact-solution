using System;

namespace FindExactSolution.Domain.Entities
{
    public class EventQuestion
    {
        public Guid EventId { get; set; }

        public Guid QuestionId { get; set; }

        public Event Event { get; private set; }
        public Question Question { get; private set; }
    }
}