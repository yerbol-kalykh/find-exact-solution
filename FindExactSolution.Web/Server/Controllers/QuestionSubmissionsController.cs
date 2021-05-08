using FindExactSolution.Application.Challenges.Models;
using FindExactSolution.Application.QuestionSubmissions.Command.SubmitAnswer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Controllers
{
    [Route("api/events/{eventId}/questions/{questionId}/questionSubmissions")]
    public class QuestionSubmissionsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<QuestionSubmissionChallengeDto>> Create([FromRoute]Guid eventId, [FromRoute] Guid questionId, SubmitAnswerCommand command)
        {
            if (eventId != command.EventId || questionId != command.QuestionId) return BadRequest();

            return Ok(await Mediator.Send(command));
        }
    }
}