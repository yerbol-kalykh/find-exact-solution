using FindExactSolution.Web.Client.Areas.Admin.Common.Resources.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Areas.Admin.Common.Interfaces
{
    public interface IAdminResultService
    {
        Task<IEnumerable<AdminResultEventResource>> GenerateLeaderboardAsync(Guid eventId);
    }
}
