using Core.Repositry;
using Microsoft.AspNetCore.Mvc;
using DAL.Model;
namespace MVCRepositry.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepositry<Book> _repositry;
        public BookController(IRepositry<Book> repositry)
        {
            _repositry = repositry;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books =await _repositry.GetAllWithEntityAsync(new string[] { "Autho" });
            return View(books);
        }
        [HttpGet("FindByName")]
        public IActionResult FindByName(string title)
        {
            var book = _repositry.FindBy(b => b.Title == title);
            return View(book);  
        }

    }
}
