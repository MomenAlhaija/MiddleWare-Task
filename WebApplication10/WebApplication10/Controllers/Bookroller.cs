using Core.Repositries;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication10.Controllers
{
    public class Bookroller : Controller
    {
        private readonly IRepositry<Book> _repositry;
        public Bookroller(IRepositry<Book> repositry)
        {
            _repositry = repositry;
        }
        [Route("Books/Index")]
        [HttpGet]
        public IActionResult Index()
        {
            var books=_repositry.GetAll().ToList();
            return View(books);
        }
    }
}
