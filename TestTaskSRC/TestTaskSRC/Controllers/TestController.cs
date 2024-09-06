using Microsoft.AspNetCore.Mvc;

namespace TestTaskSRC.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> RequestDateOnly([FromBody] DateOnly dateOnly)
        {
            return Ok(dateOnly);
        }
    }
}
