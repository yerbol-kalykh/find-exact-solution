using FindExactSolution.Domain.Common;
using FindExactSolution.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FindExactSolution.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Team> Teams { get; set; } = new List<Team>();

        public IList<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
