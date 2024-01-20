using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication6.DbComtext;
using WebApplication6.Model.Model;
using WebApplication6.Service;
using WebApplication6.ViewModel;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _book;
        public BookController(BookService db) {
        
            _book = db;
        }
        [HttpPost("Add_Book")]
        public async Task<IActionResult> AddBook(BookVM book)
        {
            _book.AddBook(book);
            return Ok(book);
        }
        [HttpGet("Get All Books")]
        public   IActionResult GetBook()
        {
            var books= _book.GetAllBooks();
            return Ok(books);
        }

    }
}
