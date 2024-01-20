using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace APIpref.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger _log;
        public ValuesController(ILogger log)
        {
            _log = log;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
