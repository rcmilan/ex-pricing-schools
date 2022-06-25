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

        public DatabaseContext Context => _context;

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _context.Set<TEntity>().AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return entities;
        }

        public async Task<TEntity> GetAsync(TId id) => await _context.Set<TEntity>().FindAsync(id);
    }
}