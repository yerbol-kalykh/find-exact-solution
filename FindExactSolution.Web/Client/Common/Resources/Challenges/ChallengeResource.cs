using FindExactSolution.Web.Client.Common.Resources.Questions;
using System;
using System.Collections.Generic;

namespace FindExactSolution.Web.Client.Common.Resources.Challenges
{
    public class ChallengeResource
    {
        public Guid Id { get; set; }

        public int Order { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int Point { get; set; }

        public IEnumerable<QuestionChallengeResource> Questions { get; set; } = new List<QuestionChallengeResource>();
    }
}
