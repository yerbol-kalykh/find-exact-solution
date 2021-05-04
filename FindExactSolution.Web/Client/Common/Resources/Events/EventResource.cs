using System;

namespace FindExactSolution.Web.Client.Common.Resources.Events
{
    public class EventResource
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
    }
}
