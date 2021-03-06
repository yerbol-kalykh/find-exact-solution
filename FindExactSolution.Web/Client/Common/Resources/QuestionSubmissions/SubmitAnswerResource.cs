using FindExactSolution.Web.Client.Common.Validations;
using System;

namespace FindExactSolution.Web.Client.Common.Resources.QuestionSubmissions
{
    public class SubmitAnswerResource
    {
        public Guid EventId { get; set; }
        public Guid QuestionId { get; set; }

        [NotNullOrWhiteSpaceValidator]
        public string Answer { get; set; }
    }
}
