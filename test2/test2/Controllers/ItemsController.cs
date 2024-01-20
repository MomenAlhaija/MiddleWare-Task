using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using test2.Data;
using test2.Models;

namespace test2.Controllers
{
   
    public class ItemsController : Controller
    {
        public ItemsController(AppDbContext db) 
        {
            _db = db;
        }
        private readonly AppDbContext _db;
        public IActionResult Index()
        {
            IEnumerable<item> itemList= _db.Items.Include(c=>c.Category);   
            return View(itemList.ToList());
        }
        public IActionResult Add() {
            CreateSelectList(); 
            return View();  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(item Item,string Name,string Price)
        {

            if (ModelState.IsValid)
            {
                Item.Name = Name;
                Item.price = decimal.Parse(Price);
                _db.Items.Add(Item);
                _db.SaveChanges();
                TempData["success"] = "The Item has been added successfuly ";
                return RedirectToAction("Index");

            }
            else
            {
                return View(Item);
            }

        }
        public IActionResult Edit(int ?id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            CreateSelectList(item.CategoryId);

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(item item)
        {
            if (ModelState.IsValid)
            {

                _db.Items.Update(item);
                _db.SaveChanges();
                TempData["success"] = "The Item has been Edit successfuly ";

                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }

        }

        public IActionResult Delete(int? id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }
            var item= _db.Items.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            CreateSelectList(item.CategoryId);

            return View(item);
        }
        [HttpPost]
        public IActionResult Delete(item item)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Remove(item);
                _db.SaveChanges();
                TempData["success"] = "The Item has been Deleted successfuly ";

                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }
        public void CreateSelectList(int selectid=0)
        {
            List<Category> categories = _db.Categories .ToList();   
            SelectList listItem=new SelectList(categories,"Id","Name", selectid);
            ViewBag.SelectList = listItem;
        }
    }
}
