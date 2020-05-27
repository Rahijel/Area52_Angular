using System.Threading.Tasks;
using Area52_Angular.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Area52_Angular.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookshelfRepository repo;
        public BooksController(IBookshelfRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await repo.GetAllBooks();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await repo.GetBook(id);

            return Ok(book);
        }
    }
}