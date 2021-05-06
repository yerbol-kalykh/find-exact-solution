using System;

namespace FindExactSolution.Domain.Entities
{
    public class Question
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Input { get; set; }

        public string Answer { get; set; }

        public int Point { get; set; }

        public Guid ChallengeId { get; set; }

        public Challenge Challenge { get; set; }
    }
}
