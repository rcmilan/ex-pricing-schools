using app.Attributes;
using app.DTOs;
using app.Entities;
using app.Repositories;
using app.ServiceInterfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace app.Services
{
    [ScopedLifetime]
    public class SchoolService : ISchoolService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<School, int> _repository;

        public SchoolService(IMapper mapper, IRepository<School, int> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<SchoolDto> GetDto(int id)
        {
            var school = await _repository.Context.Schools
                .Include(s => s.Courses)
                    .ThenInclude(c => c.PriceRanges)
                .SingleOrDefaultAsync(s => s.Id.Equals(id));

            return _mapper.Map<SchoolDto>(school);
        }
    }
}
