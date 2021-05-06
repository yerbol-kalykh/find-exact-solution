using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Challenges;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Pages.Challenges
{
    public partial class ChallengeDetails
    {
        [Parameter]
        public Guid EventId { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        [Inject]
        public IAdminChallengeService AdminChallengeService { get; set; }

        [Inject]
        public NavigationManager UriHelper { get; set; }

        private AdminChallengeDetailsResource _challengeDetails;
        
        protected override async Task OnInitializedAsync()
        {
            try
            {
                _challengeDetails = await AdminChallengeService.GetChallengeDetailsAsync(EventId, Id);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        public void NavigateToEditChallenge()
        {
            UriHelper.NavigateTo($"/admin/events/{EventId}/challenges/{Id}/edit");
        }

        public void NavigateToCreateQuestion()
        {
            UriHelper.NavigateTo($"/admin/events/{EventId}/challenges/{Id}/questions/create");
        }
    }
}
