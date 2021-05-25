using System;

namespace FindExactSolution.Application.Area.Admin.Events.Models
{
    public class AdminTeamEventDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalMembers { get; set; }
    }
}