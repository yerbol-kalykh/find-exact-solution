using FindExactSolution.Application.Area.Admin.Results.Commands;
using FindExactSolution.Application.Area.Admin.Results.Models;
using FindExactSolution.Web.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Areas.Admin
{
    [Route("admin/api/events/{eventId}/results")]
    public class ResultsController : ApiControllerBase
    {
        [HttpPost("leaderboard/generate")]
        public async Task<ActionResult<IEnumerable<AdminResultDto>>> GenerateLeaderboard([FromRoute] Guid eventId)
        {
            if (eventId == Guid.Empty) return BadRequest();

            return Ok(await Mediator.Send(new GenerateLeaderboardCommand() { EventId = eventId }));
        }
    }
}
