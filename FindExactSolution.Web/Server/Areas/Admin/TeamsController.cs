using FindExactSolution.Application.Area.Admin.Teams.Commands.GenerateTeams;
using FindExactSolution.Application.Area.Admin.Teams.Models;
using FindExactSolution.Web.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Areas.Admin
{
    [Route("admin/api/teams")]
    public class TeamsController : ApiControllerBase
    {
        [HttpPost("{eventId}")]
        public async Task<ActionResult<IEnumerable<AdminTeamDto>>> GenerateTeams([FromRoute] Guid eventId, GenerateTeamsCommand command)
        {
            if(eventId != command.EventId)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }
    }
}
