
using Microsoft.AspNetCore.Mvc;
using Core.Repositry;
using DAL.Model;

namespace MVCRepositry.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IRepositry<Autho> _repositry;
        public AuthorsController(IRepositry<Autho> repositry)
        {
            _repositry = repositry;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var authors = _repositry.GetAllAsync();
            return View(authors);
        }

    }
}
