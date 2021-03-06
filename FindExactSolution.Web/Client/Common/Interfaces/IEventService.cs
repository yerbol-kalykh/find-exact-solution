using FindExactSolution.Web.Client.Common.Resources.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Common.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventResource>> GetAllEventsAsync();

        Task<EventDetailsResource> GetEventByIdAsync(Guid id);
    }
}
