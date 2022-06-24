using app.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app.Database.Configurations
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasQueryFilter(s => s.IsActive);

            builder.HasMany(s => s.Courses)
                .WithOne()
                .HasForeignKey("SchoolId");
        }
    }
}
