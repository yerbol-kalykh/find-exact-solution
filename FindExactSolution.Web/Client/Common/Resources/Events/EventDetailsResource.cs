using System;

namespace FindExactSolution.Web.Client.Common.Resources.Events
{
    public class EventDetailsResource
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public bool IsCurrentUserRegistered { get; set; }
    }
}
