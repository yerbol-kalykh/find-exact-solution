using FindExactSolution.Web.Client.Common.Interfaces;
using FindExactSolution.Web.Client.Common.Resources.Events;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Pages.Events
{
    public partial class EventsOverview
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }

        private IEnumerable<EventResource> _events;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _events = await EventDataService.GetAllEventsAsync();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}
