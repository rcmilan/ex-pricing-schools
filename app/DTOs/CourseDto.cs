namespace app.DTOs
{
    public class CourseDto : BaseDto
    {
        public string Title { get; set; }

        public decimal RegistrationFee { get; set; }

        public IEnumerable<CoursePriceRangeDto> PriceRanges { get; set; }
    }

    public class CoursePriceRangeDto : BaseDto
    {
        public int RangeFrom { get; set; }

        public int RangeTo { get; set; }

        public decimal Price { get; set; }
    }
}
