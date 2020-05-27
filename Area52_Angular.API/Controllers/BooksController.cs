using System.Collections.Generic;
using System.Threading.Tasks;
using Area52_Angular.API.Data;
using Area52_Angular.API.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Area52_Angular.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookshelfRepository repo;
        private readonly IMapper mapper;
        public BooksController(IBookshelfRepository repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await repo.GetAllBooks();

            var booksToReturn = mapper.Map<IEnumerable<BookForListDTO>>(books);

            return Ok(booksToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await repo.GetBook(id);

            return Ok(book);
        }
    }
}