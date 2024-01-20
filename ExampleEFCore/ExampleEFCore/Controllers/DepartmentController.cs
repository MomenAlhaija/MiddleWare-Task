using ExampleEFCore.data;
using ExampleEFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleEFCore.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly MyAppDbContext _context;
        public DepartmentController(MyAppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var deps=_context.Departments.Include(p=>p.Employee).ToList(); 
            return View(deps);
        }
        public IActionResult AddDepartment() {
        
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(Department dep) { 
            _context.Add(dep);
            await _context.SaveChangesAsync();
            return RedirectToAction("AddDepartment");
        
        }
        public async Task<IActionResult> Update(int id) {
            Department dep = await _context.Departments.Where(e => e.Id == id).FirstOrDefaultAsync();
            return View(dep);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Department dep) {
        
            _context.Update(dep);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
       
    }
}
