using app.Database;
using app.Entities;
using app.Repositories;
using Microsoft.EntityFrameworkCore;

namespace app.Configuration
{
    public static class ModuleDependency
    {
        public static void AddServices(this IServiceCollection services)
        {
            services
                .AddDbContext<DatabaseContext>(options => options.UseSqlServer("Server=host.docker.internal,1433;database=abroad;User Id=sa;Password=msSQL@123;"))
                .AddScoped<IRepository<School, int>, Repository<School, int>>()
                ;
        }
    }
}
