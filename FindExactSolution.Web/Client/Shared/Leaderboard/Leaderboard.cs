using FindExactSolution.Web.Client.Common.Resources.Results;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace FindExactSolution.Web.Client.Shared.Leaderboard
{
    public partial class Leaderboard
    {
        [Parameter]
        public IEnumerable<ResultEventResource> Results { get; set; }
    }
}
