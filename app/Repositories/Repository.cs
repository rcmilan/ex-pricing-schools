using app.Entities;

namespace app.Repositories
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : BaseEntity
    {
        public Task<TEntity> GetAsync(TId id)
        {
            throw new NotImplementedException();
        }
    }
}
