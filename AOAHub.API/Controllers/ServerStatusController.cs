using Microsoft.AspNetCore.Mvc;

namespace AOAHub.API.Controllers
{

    [ApiController]
    [Route("server")]
    public class ServerStatusController : Controller
    {
        [HttpGet]
        [Route("status")]
        public IActionResult GetServerStatus()
        {
            return Ok("Server is running");
        }
    }
}
