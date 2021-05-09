using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Challenges;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Registrations;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Results;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Teams;
using System;
using System.Collections.Generic;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Events
{
    public class AdminEventDetailResource
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsOpen { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public IEnumerable<AdminTeamEventResource> Teams { get; set; } = new List<AdminTeamEventResource>();

        public IEnumerable<AdminRegistrationEventResource> Registrations { get; set; } = new List<AdminRegistrationEventResource>();

        public IEnumerable<AdminChallengeEventResource> Challenges { get; set; } = new List<AdminChallengeEventResource>();

        public IEnumerable<AdminResultEventResource> Results { get; set; } = new List<AdminResultEventResource>();
    }
}
