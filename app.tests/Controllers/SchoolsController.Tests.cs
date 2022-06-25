using System.Net;
using app.Requests;
using Bogus;

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

            var schools = new Faker<AddSchool>()
                .RuleFor(s => s.FantasyName, f => f.Commerce.Random.Words(3))
                .RuleFor(s => s.LegalName, f => f.Company.CompanyName())
                .RuleFor(s => s.Courses,
                    new Faker<AddCourse>()
                    .RuleFor(c => c.BookChargedBefore, f => f.Random.Bool())
                    .RuleFor(c => c.Title, f => f.Commerce.ProductName())
                    .RuleFor(c => c.RegistrationFee, f => f.Random.Decimal(0, 500))
                    .RuleFor(c => c.PriceRanges,
                        new List<AddCoursePriceRange>
                        {
                            new Faker<AddCoursePriceRange>()
                                .RuleFor(pr => pr.Price, f => f.Random.Decimal(200, 500))
                                .RuleFor(pr => pr.RangeFrom, 2)
                                .RuleFor(pr => pr.RangeTo, 5)
                                .Generate(),
                            new Faker<AddCoursePriceRange>()
                                .RuleFor(pr => pr.Price, f => f.Random.Decimal(100, 199))
                                .RuleFor(pr => pr.RangeFrom, 6)
                                .RuleFor(pr => pr.RangeTo, 10)
                                .Generate(),
                            new Faker<AddCoursePriceRange>()
                                .RuleFor(pr => pr.Price, f => f.Random.Decimal(50, 99))
                                .RuleFor(pr => pr.RangeFrom, 11)
                                .RuleFor(pr => pr.RangeTo, 25)
                                .Generate(),
                            new Faker<AddCoursePriceRange>()
                                .RuleFor(pr => pr.Price, f => f.Random.Decimal(10, 49))
                                .RuleFor(pr => pr.RangeFrom, 26)
                                .RuleFor(pr => pr.RangeTo, 52)
                                .Generate(),
                        }
                    )
                    .GenerateBetween(1, 10)
                )
                .Generate(100);


            var byteContent = schools.BuildByteContent();

            // Act
            var response = await client.PostAsync(BASE_PATH, byteContent, CancellationToken.None);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
