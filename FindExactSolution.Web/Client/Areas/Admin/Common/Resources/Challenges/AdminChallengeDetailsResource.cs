using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions;
using System;
using System.Collections.Generic;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Challenges
{
    public class AdminChallengeDetailsResource
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Point { get; set; }
        public AdminChallengeEventResource Event { get; set; }
        public IEnumerable<AdminQuestionChallengeResource> Questions { get; set; } = new List<AdminQuestionChallengeResource>();
    }
}