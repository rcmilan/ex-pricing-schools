namespace app.Entities
{
    public class School : BaseEntity
    {
        public string LegalName { get; set; }
        public string FantasyName { get; set; }

        public IEnumerable<Course> Courses { get; set; }
    }
}