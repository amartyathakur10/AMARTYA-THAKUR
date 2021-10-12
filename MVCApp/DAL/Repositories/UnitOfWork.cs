using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext db;
        public UnitOfWork()
        {
            db = new AppDbContext();
        }
        private IAuthRepository _AuthRepo;
        public IAuthRepository AuthRepo
        {
            get
            {
                if (_AuthRepo == null)
                    _AuthRepo = new AuthRepository(db);

                return _AuthRepo;
            }
        }

        private IRepository<Category> _CategoryRepo;
        public IRepository<Category> CategoryRepo
        {
            get
            {
                if (_CategoryRepo == null)
                    _CategoryRepo = new Repository<Category>(db);

                return _CategoryRepo;
            }
        }
        private IRepository<Product> _ProductRepo;
        public IRepository<Product> ProductRepo
        {
            get
            {
                if (_ProductRepo == null)
                    _ProductRepo = new Repository<Product>(db);

                return _ProductRepo;
            }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
