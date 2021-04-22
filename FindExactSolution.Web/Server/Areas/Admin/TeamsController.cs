using FindExactSolution.Application.Area.Admin.Teams.Commands.GenerateTeams;
using FindExactSolution.Web.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Areas.Admin
{
    [Route("admin/api/teams")]
    public class TeamsController : ApiControllerBase
    {
        [HttpPost("{eventId}")]
        public async Task<ActionResult> GenerateTeams([FromRoute] Guid eventId, GenerateTeamsCommand command)
        {
            if(eventId != command.EventId)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
