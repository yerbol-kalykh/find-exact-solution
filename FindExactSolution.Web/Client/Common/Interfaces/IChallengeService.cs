using FindExactSolution.Web.Client.Common.Resources.Challenges;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Client.Common.Interfaces
{
    public interface IChallengeService
    {
        Task<ChallengesResultResource> GetAllChallengesAsync(Guid eventId);
    }
}