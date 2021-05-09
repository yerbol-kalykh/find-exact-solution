using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Challenges;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.JSInterop;
using System;
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

        private ChallengesResultResource _challengesResult;

        private ChallengeResource _currentChallenge;

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _challengesResult = await ChallengeService.GetAllChallengesAsync(EventId);

                if(_challengesResult != null)
                {
                    await JSRuntime.InvokeVoidAsync("ClockFunctions.startTime", "timerDiv", _challengesResult.Event.EndDateTime);
                }

                _currentChallenge = _challengesResult.Challenges.FirstOrDefault();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        private void ChangeChallenge(Guid id)
        {
            _currentChallenge = _challengesResult.Challenges.FirstOrDefault(q => q.Id == id);
        }

        public void Dispose()
        {
            JSRuntime.InvokeVoidAsync("stopTime");
        }
    }
}