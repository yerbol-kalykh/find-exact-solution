using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindExactSolution.Web.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LeaderboardController : ControllerBase
    {
        
    }
}
