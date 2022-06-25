namespace app.Requests
{
    public class AddCourse
    {
        public string Title { get; set; }

        public bool BookChargedBefore { get; set; }

        public decimal RegistrationFee { get; set; }

        public IEnumerable<AddCoursePriceRange> PriceRanges { get; set; }
    }

    public class AddCoursePriceRange
    {
        public int RangeFrom { get; set; }

        public int RangeTo { get; set; }

        public decimal Price { get; set; }
    }
}