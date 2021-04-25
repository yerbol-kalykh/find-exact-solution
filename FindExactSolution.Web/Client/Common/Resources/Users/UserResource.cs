using System;

namespace FindExactSolution.Web.Client.Common.Resources.Users
{
    public class UserResource
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}