using app.DTOs;
using app.Requests;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(new SchoolDto());
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetSchoolsRequest request)
        {
            return Ok(new SchoolGridDto());
        }
    }
}
