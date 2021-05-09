using FindExactSolution.Web.Client.Common.Resources.Results;
using FindExactSolution.Web.Client.Common.Resources.Teams;
using System;
using System.Collections.Generic;

namespace FindExactSolution.Web.Client.Common.Resources.Events
{
    public class EventDetailsResource
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public bool IsOpen { get; set; }
        public bool IsCurrentUserRegistered { get; set; }

        public TeamResource Team { get; set; }

        public IEnumerable<ResultEventResource> Results { get; set; } = new List<ResultEventResource>();
    }
}