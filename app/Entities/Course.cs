namespace app.Entities
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public bool BookChargedBefore { get; set; }

        public decimal RegistrationFee { get; set; }

        public IEnumerable<CoursePriceRange> PriceRanges { get; set; }
    }
}