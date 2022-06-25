using app.Entities;
using app.Repositories;
using app.Requests;
using app.Responses;
using app.ServiceInterfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISchoolService service;

        public SchoolsController(IMapper mapper, ISchoolService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromServices] IRepository<School, int> repository, IEnumerable<AddSchool> addSchools, CancellationToken cancellationToken)
        {
            var newSchools = mapper.Map<IEnumerable<School>>(addSchools);

            var result = await repository.AddAsync(newSchools, cancellationToken);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var result = await service.GetDto(id);

            return result == null ? NotFound(id) : Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetSchools request, CancellationToken cancellationToken)
        {
            return Ok(new SchoolGrid());
        }
    }
}