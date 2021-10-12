using DomainModels;

namespace DAL.Repositories.Interfaces
{
    public interface IAuthRepository : IRepository<User>
    {
        UserModel ValidateUser(string Username, string Password);
    }
}
