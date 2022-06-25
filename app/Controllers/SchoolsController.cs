using app.DTOs;
using app.Entities;
using app.Repositories;
using app.Requests;
using app.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepository<School, int> repository;

        public SchoolsController(IMapper mapper, IRepository<School, int> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var school = await repository.GetAsync(id);

            var result = mapper.Map<SchoolDto>(school);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetSchools request, CancellationToken cancellationToken)
        {
            return Ok(new SchoolGrid());
        }

        [HttpPost]
        public async Task<IActionResult> Add(IEnumerable<AddSchool> addSchools, CancellationToken cancellationToken)
        {
            var newSchools = mapper.Map<IEnumerable<School>>(addSchools);

            var result = await repository.AddAsync(newSchools, cancellationToken);

            return Ok(result);
        }
    }
}