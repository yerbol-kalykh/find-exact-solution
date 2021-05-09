using FindExactSolution.Application.Leaderboard.Models;
using FindExactSolution.Application.Leaderboard.Queries.GetLeaderboard;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Controllers
{
    [Route("api/events/{eventId}/leaderboard")]
    public class LeaderboardController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<LeaderboardDto>> GetLeaderboard([FromRoute] Guid eventId)
        {
            if (eventId == Guid.Empty) return BadRequest();

            return Ok(await Mediator.Send(new GetLeaderboardQuery() { EventId = eventId }));
        }
    }
}
