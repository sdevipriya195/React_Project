using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Interfaces;
using Bookstore.Models.DTOS;
using Microsoft.AspNetCore.Cors;

namespace Bookstore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("reactApp")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookDTO bookDTO)
        {
            if (_bookService.Add(bookDTO))
            {
                return Ok("Book added successfully");
            }

            return BadRequest("Failed to add book");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveBook(int id)
        {
            if (_bookService.Remove(id))
            {
                return Ok("Book removed successfully");
            }

            return NotFound("Book not found");
        }

        [HttpPut]
        public IActionResult UpdateBook([FromBody] BookDTO bookDTO)
        {
            var updatedBook = _bookService.Update(bookDTO);

            if (updatedBook != null)
            {
                return Ok(updatedBook);
            }

            return NotFound("Book not found");
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);

            if (book != null)
            {
                return Ok(book);
            }

            return NotFound("Book not found");
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetBooks();

            return Ok(books);
        }

        [HttpGet("genre/{genre}")]
        public IActionResult GetBooksByGenre(string genre)
        {
            var booksByGenre = _bookService.GetBooksByGenre(genre);

            if (booksByGenre.Count > 0)
            {
                return Ok(booksByGenre);
            }

            return NotFound($"No books found for the genre: {genre}");
        }

        [HttpGet("author/{author}")]
        public IActionResult GetBooksByAuthor(string author)
        {
            var booksByAuthor = _bookService.GetBooksByAuthor(author);

            if (booksByAuthor.Count > 0)
            {
                return Ok(booksByAuthor);
            }

            return NotFound($"No books found for the author: {author}");
        }

        [HttpGet("title/{title}")]
        public IActionResult GetBooksByTitle(string title)
        {
            var booksByTitle = _bookService.GetBooksByTitle(title);

            if (booksByTitle.Count > 0)
            {
                return Ok(booksByTitle);
            }

            return NotFound($"No books found for the author: {title}");
        }
    }
}
