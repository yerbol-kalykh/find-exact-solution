using FindExactSolution.Application.Registrations.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FindExactSolution.Web.Server.Controllers
{
    [Route("api/registrations")]
    public class RegistrationController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateRegistrationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
