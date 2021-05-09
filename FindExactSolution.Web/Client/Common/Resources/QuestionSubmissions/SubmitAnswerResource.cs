using FindExactSolution.Web.Client.Common.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace FindExactSolution.Web.Client.Common.Resources.QuestionSubmissions
{
    public class SubmitAnswerResource
    {
        public Guid EventId { get; set; }
        public Guid QuestionId { get; set; }

        [NotNullOrWhiteSpaceValidator(ErrorMessage = "HELLO")]
        public string Answer { get; set; }
    }
}
