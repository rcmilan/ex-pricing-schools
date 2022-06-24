using app.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Database.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasQueryFilter(s => s.IsActive);

            builder.OwnsMany(c => c.PriceRanges, pr =>
            {
                pr.WithOwner().HasForeignKey("CourseId");
            });
        }
    }
}
