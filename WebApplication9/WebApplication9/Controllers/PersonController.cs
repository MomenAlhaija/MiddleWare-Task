using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using WebApplication9.Data;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class PersonController : Controller
    {
        private readonly AppDbContext _db;
        public PersonController(AppDbContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            var Persons=_db.Persons;
            return View(Persons.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            _db.Persons.Add(person);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? Id) {
            if (Id != null) {
                var person=_db.Persons.FirstOrDefault(x => x.Id == Id);
                if (person != null)
                {
                    return View(person);
                }
                return NotFound($"Not found Person with {Id}"); 
            }
            return null;
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {
           _db.Update(person);
            _db.SaveChanges();
            return RedirectToAction("Index");   
        }

        public IActionResult Delete(int? Id) { 
         
            if(Id!= null) { 
                
                var person=_db.Persons.FirstOrDefault(y => y.Id == Id);
                if (person != null)
                {
                    _db.Persons.Remove(person);
                    _db.SaveChanges();
                    return RedirectToAction("Index");

                }
                return NotFound($"Not Fount User Wii5h Id:{Id}");
            }
            return null;
        }
    }
}
