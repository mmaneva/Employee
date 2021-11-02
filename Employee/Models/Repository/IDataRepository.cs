using System.Collections.Generic;

namespace Employees.Repository
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
