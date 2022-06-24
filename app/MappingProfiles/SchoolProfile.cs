using app.DTOs;
using app.Entities;
using AutoMapper;

namespace app.MappingProfiles
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<School, SchoolDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FantasyName));
        }
    }
}
