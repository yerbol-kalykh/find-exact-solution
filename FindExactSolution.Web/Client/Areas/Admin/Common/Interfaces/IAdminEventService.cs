using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces
{
    public interface IAdminEventService
    {
        Task<IEnumerable<AdminEventResource>> GetAllEventsAsync();
        Task<AdminEventDetailResource> GetEventDetailAsync(Guid id);
    }
}
