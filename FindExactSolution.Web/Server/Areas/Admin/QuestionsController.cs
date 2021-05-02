using FindExactSolution.Application.Area.Admin.Questions.Commands.CreateQuestion;
using FindExactSolution.Application.Area.Admin.Questions.Commands.EditQuestion;
using FindExactSolution.Application.Area.Admin.Questions.Queries.GetQuestionDetails;
using FindExactSolution.Web.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Areas.Admin
{
    [Route("admin/api/events/{eventId}/questions")]
    public class QuestionsController : ApiControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get([FromRoute] Guid eventId, [FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetQuestionDetailsQuery { EventId = eventId, Id = id}));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromRoute] Guid eventId, CreateQuestionCommand command)
        {
            if (eventId != command.EventId)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid eventId, Guid id, EditQuestionCommand command)
        {
            if (id != command.Id || eventId != command.EventId)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }
    }
}