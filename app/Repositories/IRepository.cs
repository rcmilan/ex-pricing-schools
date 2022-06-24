using app.Entities;

namespace app.Repositories
{
    public interface IRepository<TEntity, TId> where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(TId id);
    }
}
