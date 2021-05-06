using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Challenges;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Pages.Challenges
{
    public partial class EventChallenges
    {
        [Parameter]
        public Guid EventId { get; set; }

        [Inject]
        public IChallengeService ChallengeService { get; set; }

        private IEnumerable<ChallengeResource> _challenges;

        private ChallengeResource _currentChallenge;

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _challenges = await ChallengeService.GetAllChallengesAsync(EventId);

                _currentChallenge = _challenges.FirstOrDefault();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        private void ChangeChallenge(Guid id)
        {
            _currentChallenge = _challenges.FirstOrDefault(q=>q.Id == id);
        }
    }
}