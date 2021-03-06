using System;
using System.ComponentModel.DataAnnotations;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions
{
    public class AdminQuestionCreateResource
    {
        public Guid ChallengeId { get; set; }
        public string Description { get; set; }

        [Required]
        public string Input { get; set; }
        
        [Required]
        public string Answer { get; set; }

        public int Point { get; set; }
    }
}
