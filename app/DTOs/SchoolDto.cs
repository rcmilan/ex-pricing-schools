namespace app.DTOs
{
    public class SchoolDto : BaseDto
    {
        public string Name { get; set; }
        public IEnumerable<CourseDto> Courses { get; set; }
    }
}