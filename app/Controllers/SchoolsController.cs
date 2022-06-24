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
        public async Task<IActionResult> Add(AddSchool addSchool, CancellationToken cancellationToken)
        {
            var courses = new List<Course>();

            addSchool.Courses.ToList().ForEach(c =>
            {
                var course = new Course
                {
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    Title = c.Title,
                    BookChargedBefore = c.BookChargedBefore,
                    RegistrationFee = c.RegistrationFee,
                    PriceRanges = new List<CoursePriceRange>()
                };
                c.PriceRanges
                .ToList()
                .ForEach(pr => course.PriceRanges
                    .ToList().Add(new CoursePriceRange
                    {
                        CreatedAt = DateTime.Now,
                        IsActive = true,
                        Price = pr.Price,
                        RangeFrom = pr.RangeFrom,
                        RangeTo = pr.RangeTo
                    })
                );

                courses.Add(course);
            });

            var s = new School
            {
                IsActive = true,
                CreatedAt = DateTime.Now,
                FantasyName = addSchool.FantasyName,
                LegalName = addSchool.LegalName,
                Courses = courses
            };

            var result = await repository.AddAsync(s);

            return Ok(result);
        }
    }
}