using System;

namespace FindExactSolution.Domain.Common
{
    public interface IUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }
    }
}
