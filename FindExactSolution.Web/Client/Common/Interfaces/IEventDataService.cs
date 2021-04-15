using FindExactSolution.Web.Client.Common.Resources.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Common.Interfaces
{
    public interface IEventDataService
    {
        Task<IEnumerable<EventResource>> GetAllEventsAsync();
    }
}
