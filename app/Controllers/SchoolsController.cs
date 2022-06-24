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
        private readonly IRepository<School, int> repository;
        private readonly IMapper mapper;

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
        public async Task<IActionResult> Get([FromQuery] GetSchoolsRequest request, CancellationToken cancellationToken)
        {
            return Ok(new SchoolGrid());
        }
    }
}
