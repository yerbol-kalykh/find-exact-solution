using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Questions;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Registrations;
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

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public IEnumerable<AdminTeamEventResource> Teams { get; set; }

        public IEnumerable<AdminRegistrationEventResource> Registrations { get; set; }

        public IEnumerable<AdminQuestionEventResource> Questions { get; set; }

        public AdminEventDetailResource()
        {
            Teams = new List<AdminTeamEventResource>();
            Registrations = new List<AdminRegistrationEventResource>();
            Questions = new List<AdminQuestionEventResource>();
        }
    }
}
