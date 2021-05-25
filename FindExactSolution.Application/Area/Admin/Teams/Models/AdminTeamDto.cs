using System;

namespace FindExactSolution.Application.Area.Admin.Teams.Models
{
    public class AdminTeamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalMembers { get; set; }
    }
}
