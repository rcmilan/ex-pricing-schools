namespace app.Entities
{
    public class CoursePriceRange : BaseEntity
    {
        public int RangeFrom { get; set; }

        public int RangeTo { get; set; }

        public decimal Price { get; set; }
    }
}