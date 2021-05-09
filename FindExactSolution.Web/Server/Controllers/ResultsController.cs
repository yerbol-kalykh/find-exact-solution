using FindExactSolution.Application.Area.Admin.Results.Commands;
using FindExactSolution.Application.Area.Admin.Results.Models;
using FindExactSolution.Application.Leaderboards.Models;
using FindExactSolution.Application.Leaderboards.Queries.GetLeaderboard;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Controllers
{
    [Route("api/events/{eventId}/results")]
    public class ResultsController : ApiControllerBase
    {
        [HttpGet("leaderboard")]
        public async Task<ActionResult<LeaderboardDto>> GetLeaderboard([FromRoute] Guid eventId)
        {
            if (eventId == Guid.Empty) return BadRequest();

            return Ok(await Mediator.Send(new GetLeaderboardQuery() { EventId = eventId }));
        }
    }
}
