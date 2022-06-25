using app.Entities;
using app.Requests;
using AutoMapper;

namespace app.MappingProfiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<AddCourse, Course>();

            CreateMap<AddCoursePriceRange, CoursePriceRange>();
        }
    }
}
