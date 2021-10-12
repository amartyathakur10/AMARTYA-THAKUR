using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _db;
        public Repository(DbContext db)
        {
            _db = db;
        }
        public void Add(TEntity model)
        {
            _db.Set<TEntity>().Add(model);
        }

        public void Delete(object Id)
        {
           TEntity entity= _db.Set<TEntity>().Find(Id);
            if (entity != null)
                _db.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public TEntity GetById(object Id)
        {
            return _db.Set<TEntity>().Find(Id);
        }

        public void Modify(TEntity model)
        {
            _db.Entry<TEntity>(model).State= EntityState.Modified;
        }
    }
}
