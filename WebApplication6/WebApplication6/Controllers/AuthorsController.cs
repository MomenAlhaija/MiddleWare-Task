using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Data.Model;
using WebApplication6.Service;
using WebApplication6.ViewModel;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _author;
        public AuthorsController(AuthorService author)
        {
            _author = author;
        }
        [HttpPost("Add_Author")]
        public async Task<IActionResult> addAuthor(AuthorVM newAuthor)
        {
            _author.AddAuthor(newAuthor);
            return Ok();
        }
        [HttpGet("Get_All_Authors_With_Books")]
        public IActionResult authorsWithBooks()
        {
            var Authors = _author.getAllAuthors();
            return Ok(Authors);
        }
    }
}
