using FindExactSolution.Application.Events.Models;
using FindExactSolution.Application.Events.Queries.GetEvents;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Controllers
{
    public class EventsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetAllEvents()
        {
            return Ok(await Mediator.Send(new GetEventsQuery()));
        }
    }
}