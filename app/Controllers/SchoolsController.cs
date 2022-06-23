using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }
    }
}
