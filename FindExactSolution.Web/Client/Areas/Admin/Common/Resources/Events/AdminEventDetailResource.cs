using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Teams;
using System;
using System.Collections.Generic;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Events
{
    public class AdminEventDetailResource
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public IEnumerable<AdminTeamResource> Teams { get; set; }

        public AdminEventDetailResource()
        {
            Teams = new List<AdminTeamResource>();
        }
    }
}
