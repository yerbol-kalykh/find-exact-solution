using System;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions
{
    public class AdminQuestionChallengeResource
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Input { get; set; }

        public string Answer { get; set; }

        public int Point { get; set; }
    }
}
