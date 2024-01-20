using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Secondcore.Data;
using Secondcore.Models;

namespace Secondcore.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext _db;
        public ItemsController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> Products=_db.Items.ToList();
            return View(Products);
        }
        public IActionResult Add()
        {
            CreateSelectList();
            return View();  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Item item)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(item);
                _db.SaveChanges();
                TempData["SuccessData"] = "Item has been Added Successfully";
                CreateSelectList(Convert.ToInt32(item.CategoryId));
                return RedirectToAction("Index");

            }
            return View(item);
        }
        public IActionResult Edit(int? id)
        {
            CreateSelectList();
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item=_db.Items.FirstOrDefault(x => x.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            CreateSelectList(Convert.ToInt32(item.CategoryId));
            return View(item);
        }
        public void CreateSelectList(int SelectId=1)
        {
            List<Category> Categories = _db.Categories.ToList();    
            SelectList ListItem = new SelectList(Categories, "Id", "Name", SelectId);
            ViewBag.SelectList = ListItem;
        }
        [HttpPost]
        public IActionResult Edit(Item item)
        {

            if (ModelState.IsValid)
            {
                _db.Items.Update(item);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(item);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.Items.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Delete(Item item)
        {

            if (ModelState.IsValid)
            {
                _db.Items.Update(item);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(item);
        }

    }
}
