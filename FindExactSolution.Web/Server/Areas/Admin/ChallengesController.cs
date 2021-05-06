using FindExactSolution.Application.Area.Admin.Challenges.Commands.CreateChallenge;
using FindExactSolution.Application.Area.Admin.Challenges.Commands.EditChallenge;
using FindExactSolution.Application.Area.Admin.Challenges.Queries.GetChallengeDetails;
using FindExactSolution.Web.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Areas.Admin
{
    [Route("admin/api/events/{eventId}/challenges")]
    public class ChallengesController : ApiControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get([FromRoute] Guid eventId, [FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetChallengeDetailsQuery { EventId = eventId, Id = id}));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromRoute] Guid eventId, CreateChallengeCommand command)
        {
            if (eventId != command.EventId)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid eventId, Guid id, EditChallengeCommand command)
        {
            if (id != command.Id || eventId != command.EventId)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }
    }
}