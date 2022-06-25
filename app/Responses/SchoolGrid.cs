using app.DTOs;

namespace app.Responses
{
    public class SchoolGrid : BaseDto
    {
        public string Name { get; set; }
        public string SlugName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseSlugName { get; set; }
        public string CourseDescription { get; set; }
        public string CoursePeriod { get; set; }

        public int AccommodationId { get; set; }
        public string AccommodationType { get; set; }
        public string AccommodationSlugName { get; set; }
        public string AccommodationDescription { get; set; }
        public string AccommodationBedroomType { get; set; }

        public string Category { get; set; }
        public bool HasDiscount { get; set; }
        public bool HasSupplement { get; set; }

        public decimal OriginalPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public decimal Discount { get => Math.Max(OriginalPrice - FinalPrice, 0); }
    }
}