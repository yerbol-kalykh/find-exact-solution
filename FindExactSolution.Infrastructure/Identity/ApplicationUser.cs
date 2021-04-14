using FindExactSolution.Domain.Common;
using FindExactSolution.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FindExactSolution.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser, IUser
    {
        public IList<Team> Teams { get; set; } = new List<Team>();
    }
}
