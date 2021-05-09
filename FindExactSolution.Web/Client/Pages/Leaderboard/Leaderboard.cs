using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Leaderboard;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Pages.Leaderboard
{
    public partial class Leaderboard
    {
        [Parameter]
        public Guid EventId { get; set; }

        [Inject]
        public ILeaderboardService LeaderboardService { get; set; }

        private LeaderboardResource _leaderboard;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _leaderboard = await LeaderboardService.GetLeaderboardAsync(EventId);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}