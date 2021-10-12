using System.Collections.Generic;

namespace DAL.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity model);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object Id);
        void Modify(TEntity model);
        void Delete(object Id);
    }
}
