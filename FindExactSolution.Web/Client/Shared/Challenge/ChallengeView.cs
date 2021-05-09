using FindExactSolution.Web.Client.Common.Resources.Challenges;
using Microsoft.AspNetCore.Components;
using System;

namespace FindExactSolution.Web.Client.Shared.Challenge
{
    public partial class ChallengeView
    {
        [Parameter]
        public ChallengeResource SelectedChallenge { get; set; }

        [Parameter]
        public Guid EventId { get; set; }

        [Parameter]
        public bool IsOpen{ get; set; }
    }
}