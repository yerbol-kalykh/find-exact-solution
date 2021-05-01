using FindExactSolution.Application.Area.Admin.Questions.Commands.CreateQuestion;
using FindExactSolution.Web.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Areas.Admin
{
    [Route("admin/api/events/{eventId}/questions")]
    public class QuestionsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create([FromRoute] Guid eventId, CreateQuestionCommand command)
        {
            if (eventId != command.EventId)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
    }
}