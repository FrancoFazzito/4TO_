using Domain;
using System.Collections.Generic;

namespace Application
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        public TEntity GetById(int id);

        public bool Create(TEntity value);

        bool Delete(int id);

        bool Update(TEntity value);
    }
}