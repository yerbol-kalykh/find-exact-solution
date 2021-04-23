using FindExactSolution.Web.Client.Common.Resources.Teams;
using System;

namespace FindExactSolution.Web.Client.Common.Resources.Events
{
    public class EventDetailsResource
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public bool IsCurrentUserRegistered { get; set; }

        public TeamResource Team { get; set; }
    }
}
