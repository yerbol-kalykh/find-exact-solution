using System;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Events
{
    public class AdminEventResource
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
