using FindExactSolution.Application.Common.Mappings;
using FindExactSolution.Domain.Common;
using System;

namespace FindExactSolution.Application.Teams.Models
{
    public class UserTeamDto : IMapFrom<IUser>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
