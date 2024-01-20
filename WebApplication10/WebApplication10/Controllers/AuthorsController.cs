using Core.Repositries;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication10.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IRepositry<Autho> _repositry;
        public AuthorsController(IRepositry<Autho> repositry)
        {
            _repositry = repositry;
        }
        [Route("Authors/Index")]
        [HttpGet]
        public IActionResult Index()
        {
            var p= _repositry.GetAll();
            return View(p.ToList());
        }
    }
}
