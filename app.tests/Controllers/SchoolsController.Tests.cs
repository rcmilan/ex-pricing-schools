using System.Net;
using app.Requests;

namespace app.tests.Controllers
{
    internal class SchoolsController
    {
        private const string BASE_PATH = "/api/Schools";

        [Test]
        public async Task ShouldAddSchools()
        {
            // Arrange
            await using var application = new WebAppFactory("Development");
            var client = application.CreateClient();

            IEnumerable<AddSchool> schools = new List<AddSchool>
            {
                new AddSchool
                {
                    FantasyName = "",
                    LegalName = "",
                    Courses = new List<AddCourse>
                    {
                        new AddCourse
                        {
                            BookChargedBefore = false,
                            RegistrationFee = 0,
                            Title = "",
                            PriceRanges = new List<AddCoursePriceRange>
                            {
                                new AddCoursePriceRange
                                {
                                    Price = 0,
                                    RangeFrom = 0,
                                    RangeTo = 0
                                }
                            }
                        }
                    }
                }
            };

            var byteContent = schools.BuildByteContent();

            // Act
            var response = await client.PostAsync(BASE_PATH, byteContent, CancellationToken.None);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
