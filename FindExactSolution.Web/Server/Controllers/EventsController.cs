using FindExactSolution.Application.Events.Models;
using FindExactSolution.Application.Events.Queries.GetEventById;
using FindExactSolution.Application.Events.Queries.GetEvents;
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
        public async Task<ActionResult<IEnumerable<EventDto>>> GetAllEvents()
        {
            return Ok(await Mediator.Send(new GetEventsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEventById([FromRoute] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            return Ok(await Mediator.Send(new GetEventByIdQuery() { Id = id}));
        }
    }
}