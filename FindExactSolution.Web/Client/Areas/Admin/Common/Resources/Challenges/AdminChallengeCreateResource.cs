using System;
using System.ComponentModel.DataAnnotations;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Challenges
{
    public class AdminChallengeCreateResource
    {
        public Guid EventId { get; set; }

        [Required]
        [StringLength(512, ErrorMessage = "Title is too long.")]
        public string Title { get; set; }

        public string Body { get; set; }

        public int Order { get; set; }
    }
}
