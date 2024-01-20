using ExampleEFCore.data;
using ExampleEFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExampleEFCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MyAppDbContext _context;
        public EmployeeController(MyAppDbContext context) { _context = context; }
        public IActionResult Index()
        {
            var Emps=_context.Employees.Include(E=>E.Department).ToList();
            return View(Emps);
        }
        public IActionResult AddEmployee() {

            List<SelectListItem> dept = new List<SelectListItem>();
            dept = _context.Departments.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.Department = dept;
            return View();
        
        
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee emp) {

            _context.Add(emp);
            await _context.SaveChangesAsync();  
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
               List<SelectListItem> dept = new List<SelectListItem>();
            dept = _context.Departments.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.Department = dept;
            Employee emp=await _context.Employees.Where(p=>p.Id == id).FirstOrDefaultAsync();
            return View(emp);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Employee emp)
        {
            _context.Update(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var emp=await _context.Employees.Where(_ => _.Id == id).FirstOrDefaultAsync();
            _context.Remove(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
