using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication13.Data;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    [Authorize]
    public class CatsController : Controller
    {
        private readonly WebApplication13Context _context;

        public CatsController(WebApplication13Context context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            var cats=_context.Categories.ToList();
            return View(cats);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Add(Category cat) { 
        
            _context.Categories.Add(cat);
            _context.SaveChanges();
            return RedirectToAction("Index");   
        
        }
    }
}
