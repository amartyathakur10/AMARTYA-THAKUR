using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Category> CategoryRepo { get; }
        IRepository<Product> ProductRepo { get; }
        IAuthRepository AuthRepo { get; }
        void SaveChanges();
    }
}
