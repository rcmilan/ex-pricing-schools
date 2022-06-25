using app.Database;
using app.Entities;

namespace app.Repositories
{
    public interface IRepository<TEntity, TId> where TEntity : BaseEntity
    {
        DatabaseContext Context { get; }

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

        Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

        Task<TEntity> GetAsync(TId id);
    }
}