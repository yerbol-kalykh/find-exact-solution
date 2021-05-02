using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Events;
using System;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions
{
    public class AdminQuestionDetailsResource
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Point { get; set; }
        public AdminEventQuestionResource Event { get; set; }
    }
}