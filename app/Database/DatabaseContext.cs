using app.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace app.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<School> Schools { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
                t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>) && typeof(BaseEntity).IsAssignableFrom(i.GenericTypeArguments[0]))
            );

            var schools = new List<School>
            {
                new School { Id = 1, FantasyName = "School A", LegalName = "A School", IsActive = true, CreatedAt = new DateTime(2022,02,02) }
            };

            modelBuilder.Entity<School>().HasData(schools);
        }
    }
}
