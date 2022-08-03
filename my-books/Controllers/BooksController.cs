using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }


        [HttpGet("Get-All-Books")]

        public IActionResult GetAllBooks() { 
        
        var allBooks = _booksService.GetAllBooks();

            return Ok(allBooks);
        
        
        }

        [HttpGet("Get-Book-By-Id/{id}")]

        public IActionResult GetBookById(int id)
        {

            var singlebook = _booksService.GetBookById(id);

            if (singlebook != null)
            {

                return Ok(singlebook);
            }
            else {


                return BadRequest("Book does not exist");
            
            }

        }


        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody] BookVM book) {

            _booksService.AddBookWithAuthors(book);

            return Ok("succesful");
        }

        [HttpPut("Update-Boook-By-Id/{id}")]

        public IActionResult UpdateBookById(int id, [FromBody] BookVM book) { 
        
        var updatedBook = _booksService.UpdateBookById(id, book);

            return Ok(updatedBook);
        
        }


        [HttpDelete("Delete-Boook-By-Id/{id}")]

        public IActionResult UpdateBookById(int id)
        {

            _booksService.DeleteBookById(id);

            return Ok("Book was Deleted");

        }

    }
}
