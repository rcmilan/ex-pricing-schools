using app.Attributes;
using app.Database;
using Microsoft.EntityFrameworkCore;

namespace app.Configuration
{
    public static class ModuleDependency
    {
        public static void AddServices(this IServiceCollection services)
        {
            services
                .AddDbContext<DatabaseContext>(options => options.UseSqlServer("Server=host.docker.internal,1433;database=abroad;User Id=sa;Password=msSQL@123;"))
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .Scan(scan => scan
                    .FromCallingAssembly()
                        .AddClasses(c => c.WithAttribute<ScopedAttribute>())
                        .AsImplementedInterfaces()
                        .WithScopedLifetime()
                )
                ;
        }
    }
}
