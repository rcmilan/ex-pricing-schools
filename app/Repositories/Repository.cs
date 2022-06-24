using app.Attributes;
using app.Database;
using app.Entities;

namespace app.Repositories
{
    [ScopedLifetime]
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : BaseEntity
    {
        private readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetAsync(TId id)
        {
            return await _context
                .Set<TEntity>()
                .FindAsync(id);
        }
    }
}
