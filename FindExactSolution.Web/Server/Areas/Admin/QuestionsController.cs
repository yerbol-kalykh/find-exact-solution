using FindExactSolution.Application.Area.Admin.Questions.Commands.CreateQuestion;
using FindExactSolution.Application.Area.Admin.Questions.Commands.EditQuestion;
using FindExactSolution.Application.Area.Admin.Questions.Queries;
using FindExactSolution.Web.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Areas.Admin
{
    [Route("admin/api/challenges/{challengeId}/questions")]
    public class QuestionsController : ApiControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> Get([FromRoute] Guid challengeId, [FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetQuestionDetailsQuery { ChallengeId = challengeId, Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromRoute] Guid challengeId, CreateQuestionCommand command)
        {
            if (challengeId != command.ChallengeId)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid challengeId, Guid id, EditQuestionCommand command)
        {
            if (id != command.Id || challengeId != command.ChallengeId)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }
    }
}
