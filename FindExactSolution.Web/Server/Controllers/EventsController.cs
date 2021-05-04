using FindExactSolution.Application.Events.Models;
using FindExactSolution.Application.Events.Queries.GetEvents;
using FindExactSolution.Application.Events.Queries.GetUserEventById;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Controllers
{
    [Route("api/events")]
    public class EventsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetEventsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<EventDetailsDto>>> GetById([FromRoute] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            return Ok(await Mediator.Send(new GetUserEventByIdQuery() { Id = id}));
        }
    }
}