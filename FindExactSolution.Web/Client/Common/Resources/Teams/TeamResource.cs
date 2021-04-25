using FindExactSolution.Web.Client.Common.Resources.Users;
using System;
using System.Collections.Generic;

namespace FindExactSolution.Web.Client.Common.Resources.Teams
{
    public class TeamResource
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IList<UserResource> Users { get; set; } = new List<UserResource>();
    }
}