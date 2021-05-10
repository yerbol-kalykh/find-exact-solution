using FindExactSolution.Web.Client.Common.Validations;
using System;

namespace FindExactSolution.Web.Client.Common.Resources.Teams
{
    public class TeamEditResource
    {
        public Guid Id { get; set; }

        [NotNullOrWhiteSpaceValidatorAttribute]
        public string Name { get; set; }
    }
}
