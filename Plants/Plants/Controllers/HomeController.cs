using Plants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plants.Controllers
{
    public class HomeController : Controller
    {
        PlantsEntities db=new PlantsEntities();
        public ActionResult Index()
        {
            var Category = db.Categories;
            return View(Category.ToList());
        }
        public ActionResult SubCategory(int id)
        {

            var TypeCategory = db.Sub_Categories.Where(p => p.Category_id == id);
            ViewBag.BageName = TypeCategory.FirstOrDefault().Categories.Category_Name;
            return View(TypeCategory.ToList());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}