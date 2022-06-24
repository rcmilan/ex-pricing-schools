using app.DTOs;
using app.Entities;
using app.Repositories;
using app.Requests;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly IRepository<School, int> repository;

        public SchoolsController(IRepository<School, int> repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var x = await repository.GetAsync(id);

            return Ok(new SchoolDto());
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetSchoolsRequest request, CancellationToken cancellationToken)
        {
            return Ok(new SchoolGridDto());
        }
    }
}
