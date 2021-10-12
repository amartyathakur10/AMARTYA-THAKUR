using DAL.Repositories.Interfaces;
using DomainModels;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories.Implementations
{
    public class AuthRepository : Repository<User>, IAuthRepository
    {
        public AppDbContext context
        {
            get
            {
                return _db as AppDbContext;
            }
        }
        public AuthRepository(DbContext db): base(db)
        {
            
        }
        public UserModel ValidateUser(string Username, string Password)
        {
            User data = context.Users.Include("Roles").Where(u => u.Username == Username && u.Password == Password).FirstOrDefault();
            if (data != null)
            {
                UserModel user = new UserModel();

                user.UserId = data.UserId;
                user.Password = data.Password;
                user.Name = data.Name;
                user.Roles = data.Roles.Select(r => r.Name).ToArray();
                user.Username = data.Username;
                return user;
            }
            return null;
        }
    }
}
