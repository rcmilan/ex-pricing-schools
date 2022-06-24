namespace app.Requests
{
    public class GetSchoolsRequest
    {
        public string? Type { get; set; } // Idiomas/Formação
        public string? Language { get; set; }

        public string? CourseTitle { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }

        public string AccommodationType { get; set; }
        public string AccommodationBedroomType { get; set; }

        public int? WeekQuantity { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
