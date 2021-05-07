using System;

namespace FindExactSolution.Web.Client.Common.Resources.QuestionSubmissions
{
    public class SubmitAnswerResource
    {
        public Guid EventId { get; set; }
        public Guid QuestionId { get; set; }

        public string Answer { get; set; }
    }
}
