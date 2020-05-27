using System.Threading.Tasks;
using System.Collections.Generic;
using Area52_Angular.API.Models;

namespace Area52_Angular.API.Data
{
    public interface IBookshelfRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<Book>> GetAllBooks();
         Task<Book> GetBook(int id);
    }
}