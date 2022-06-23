namespace app.Requests
{
    public class GetSchoolsRequest
    {
        public string Type { get; set; } // programa
        public string Language { get; set; }

        public string CourseTitle { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }

        public int WeekQuantity { get; set; }
        public DateTime StartDate { get; set; }
    }
}
