using FindExactSolution.Web.Client.Common.Resources.Challenges;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Common.Interfaces
{
    public interface IChallengeService
    {
        Task<IEnumerable<ChallengeResource>> GetAllChallengesAsync(Guid eventId);
    }
}