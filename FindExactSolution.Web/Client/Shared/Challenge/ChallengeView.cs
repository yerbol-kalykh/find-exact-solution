using FindExactSolution.Web.Client.Common.Resources.Challenges;
using Microsoft.AspNetCore.Components;

namespace FindExactSolution.Web.Client.Shared.Challenge
{
    public partial class ChallengeView
    {
        [Parameter]
        public ChallengeResource SelectedChallenge { get; set; }
    }
}