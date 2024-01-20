using ExampleEFCore.data;
using ExampleEFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleEFCore.Controllers
{
    public class Inforamtions : Controller
    {
        private readonly MyAppDbContext _context;
        public Inforamtions(MyAppDbContext context)
        {
           _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateInformation()
        {

            var info = new Information
            {
                Name = "YogiHosting",
                License = "XXYY",
                Revenue = 1000,
                Establshied = Convert.ToDateTime("2014/06/24")
            };
            _context.Informations.Add(info);
            _context.SaveChanges();
            return View();  
        }
        public IActionResult Adddepartment() {


            var dept1 = new Department() { Name = "Development" };
            var dept2 = new Department() { Name = "HR" };
            var dept3 = new Department() { Name = "Marketing" };
            _context.AddRange(dept1, dept2, dept3);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> AddEmployee() {
            var dept = new Department()
            {
                Name = "Admin"
            };

            var emp = new Employee()
            {
                Name = "Matt",
                Designation = "Head",
                Department = dept
            };
            _context.Add(emp);
           await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
