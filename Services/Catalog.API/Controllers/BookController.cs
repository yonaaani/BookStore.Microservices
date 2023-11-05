using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository manager)
        {
            _repository = manager ?? throw new ArgumentNullException(nameof(manager));
        }

        [HttpGet("GetBooks")]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var products = await _repository.GetBooks();
            return Ok(products);
        }

        [HttpGet("GetBookById")]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Book>> GetBookById(string id)
        {
            var book = await _repository.GetBookById(id);
            return Ok(book);
        }

        [HttpGet("GetBookByTitle")]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Book>> GetBookByTitle(string title)
        {
            var book = await _repository.GetBookByTitle(title);
            return Ok(book);
        }

        [HttpGet("GetBooksByAuthor")]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Book>> GetBooksByAuthor(string authorName)
        {
            var books = await _repository.GetBooksByAuthor(authorName);
            return Ok(books);
        }

        [HttpGet("GetBooksByPublisher")]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Book>> GetBooksByPublisher(string publisher)
        {
            var books = await _repository.GetBooksByPublisher(publisher);
            return Ok(books);
        }

        [HttpGet("GetBooksByGenre")]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Book>> GetBooksByGenre(string genre)
        {
            var books = await _repository.GetBooksByGenre(genre);
            return Ok(books);
        }

        [HttpGet("GetBooksByLanguage")]
        [ProducesResponseType(typeof(IEnumerable<Book>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Book>> GetBooksByLanguage(string languageName)
        {
            var books = await _repository.GetBooksByGenre(languageName);
            return Ok(books);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Book>> CreateBook([FromBody] Book book)
        {
            await _repository.CreateBook(book);

            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBook([FromBody] Book book)
        {
            return Ok(await _repository.UpdateBook(book));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteBook")]
        [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBookById(string id)
        {
            return Ok(await _repository.DeleteBook(id));
        }
    }
}