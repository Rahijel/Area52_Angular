using System.Threading.Tasks;
using Area52_Angular.API.Models;

namespace Area52_Angular.API.Data
{
    public interface IUserRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<User> GetUser(int id);
    }
}