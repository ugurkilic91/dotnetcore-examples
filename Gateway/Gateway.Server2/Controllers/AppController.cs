using Microsoft.AspNetCore.Mvc;

namespace Gateway.Server1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppController : ControllerBase
    {
        [HttpGet("AppGet")]
        public string AppGet()
        {
            return $"Server 1 port : 20000";
        }
    }
}
