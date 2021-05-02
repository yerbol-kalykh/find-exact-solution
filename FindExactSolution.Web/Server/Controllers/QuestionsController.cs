﻿using FindExactSolution.Application.Questions.Queries.GetQuestions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Controllers
{
    [Route("api/events/{eventId}/questions")]
    public class QuestionsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll([FromRoute] Guid eventId)
        {
            return Ok(await Mediator.Send(new GetQuestionsQuery { EventId = eventId }));
        }
    }
}