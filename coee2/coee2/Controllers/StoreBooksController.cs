using coee2.Models;
using Microsoft.AspNetCore.Mvc;

namespace coee2.Controllers
{
    public class StoreBooksController : Controller
    {
        [Route("Books/{id?}/{Authorize?}")]
        [Route("/")]
        public IActionResult Index(int? BookId,[FromQuery] bool? Authorize, Book book)
        {
            if (Authorize is true)
            {
                if (book.BookId is null)
                    return NotFound();
                if (book.BookId <= 0)
                    return NotFound();
                return Content("Momen Welcome");
            }
            return NotFound();
           
        }
        [Route("About")]
        public IActionResult About()
        {
            return new RedirectToActionResult("Index", "StoreBooks", new {id=5});
        }
    }
}
