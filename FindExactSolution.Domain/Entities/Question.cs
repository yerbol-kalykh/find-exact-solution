using System;

namespace FindExactSolution.Domain.Entities
{
    public class Question
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int Point { get; set; }

        public Guid EventId { get; set; }

        public int Order { get; set; }

        public string  Input { get; set; }

        public string Answer { get; set; }

        public Event Event { get; set; }
    }
}