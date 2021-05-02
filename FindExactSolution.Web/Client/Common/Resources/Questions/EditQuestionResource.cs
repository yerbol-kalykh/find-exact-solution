using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions;
using System;
using System.ComponentModel.DataAnnotations;

namespace FindExactSolution.Web.Client.Common.Resources.Questions
{
    public class EditQuestionResource
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }

        [Required]
        [StringLength(512, ErrorMessage = "Title is too long.")]
        public string Title { get; set; }

        public string Body { get; set; }

        public int Point { get; set; }
    }
}
