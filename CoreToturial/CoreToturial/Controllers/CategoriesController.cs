using BusinesLayer;
using DataAccessLayer.Data;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace CoreToturial.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IRepositry<Category> _repositry;
        private readonly AppDbContext _context;

        public CategoriesController(IRepositry<Category> repositry,AppDbContext context)
        {
            _context = context;
           _repositry = repositry;  
        }
        [HttpGet]
        public  IActionResult Index()
        {
            var cats= _context.Categories.ToList();
            return View(cats);
        }
        

    }
}
