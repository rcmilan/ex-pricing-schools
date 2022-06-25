using app.DTOs;
using app.Entities;
using app.Requests;
using AutoMapper;

namespace app.MappingProfiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();

            CreateMap<CoursePriceRange, CoursePriceRangeDto>();

            CreateMap<AddCourse, Course>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                ;

            CreateMap<AddCoursePriceRange, CoursePriceRange>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                ;
        }
    }
}