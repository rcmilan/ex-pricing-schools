namespace app.Requests
{
    public class AddSchool
    {
        public string LegalName { get; set; }

        public string FantasyName { get; set; }

        public IEnumerable<AddCourse> Courses { get; set; }
    }
}