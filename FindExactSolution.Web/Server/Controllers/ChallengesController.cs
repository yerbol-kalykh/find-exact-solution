using FindExactSolution.Application.Challenges.Queries.GetChallenges;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Controllers
{
    [Route("api/events/{eventId}/challenges")]
    public class ChallengesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll([FromRoute] Guid eventId)
        {
            return Ok(await Mediator.Send(new GetChallengesQuery { EventId = eventId }));
        }
    }
}