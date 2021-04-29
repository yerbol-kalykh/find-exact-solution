using FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces;
using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Events;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Pages.Events
{
    public partial class Events
    {
        [Inject]
        public IAdminEventService AdminEventService { get; set; }

        private IEnumerable<AdminEventResource> _events;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _events = await AdminEventService.GetAllEventsAsync();
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}
