using System;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions
{
    public class AdminQuestionDetailsResource
    {
        public Guid Id { get; set; }
        public Guid ChallengeId { get; set; }
        public string Description { get; set; }
        public string Input { get; set; }
        public string Answer { get; set; }
        public int Point { get; set; }
    }
}
