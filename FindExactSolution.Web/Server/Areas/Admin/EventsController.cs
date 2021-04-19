using FindExactSolution.Application.Area.Admin.Events.Models;
using FindExactSolution.Application.Area.Admin.Events.Queries.GetAllEvents;
using FindExactSolution.Application.Area.Admin.Events.Queries.GetEventDetails;
using FindExactSolution.Web.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Areas.Admin
{
    [Route("admin/api/events")]
    public class EventsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetAllEvents()
        {
            return Ok(await Mediator.Send(new GetAllEventsQuery()));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEventDetails([FromRoute] Guid id)
        {
            return Ok(await Mediator.Send(new GetEventDetailsQuery() { Id = id }));
        }
    }
}
