using FindExactSolution.Application.Teams.Commands.EditTeam;
using FindExactSolution.Application.Teams.Models;
using FindExactSolution.Application.Teams.Queries.GetTeamById;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Controllers
{
    [Route("api/teams")]
    public class TeamsController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDto>> GetTeamById([FromRoute] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            return Ok(await Mediator.Send(new GetTeamByIdQuery { Id = id}));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTeam([FromRoute] Guid id, EditTeamCommand command)
        {
            if (id == Guid.Empty || id != command.Id) return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
