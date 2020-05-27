using System.Collections.Generic;
using System.Threading.Tasks;
using Area52_Angular.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Area52_Angular.API.Data
{
    public class BookshelfRepository : IBookshelfRepository
    {
        private readonly DataContext context;
        public BookshelfRepository(DataContext context)
        {
            this.context = context;
            
        }

        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public async Task<Book> GetBook(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            return book;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var books = await context.Books.ToListAsync();
            return books;
        }

        public async Task<bool> SaveAll()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}