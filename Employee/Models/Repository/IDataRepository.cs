using System.Collections.Generic;

namespace Employee.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(int id);

        void Post(TEntity entity);

        void Put(TEntity dbEntity, TEntity entity);

        void Delete(TEntity entity);
    }
}
