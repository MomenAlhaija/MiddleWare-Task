using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Plants.Models;

namespace Plants.Controllers
{
    public class ProductsController : Controller
    {
        private PlantsEntities db = new PlantsEntities();

        // GET: Products
        public ActionResult Index(int id)
        {
            var products = db.Products.Include(p => p.Sub_Categories).Where(p => p.Subcategory_id == id).OrderByDescending(p => p.Product_id);
            return View(products.ToList());
        }
        public ActionResult Index2()
        {
            var products = db.Products.Include(p => p.Sub_Categories);
            return View(products.ToList());
        }
        public ActionResult gitProducts(int id)
        {
            var products = db.Products.Include(p => p.Sub_Categories).Where(p => p.Subcategory_id == id);
            return View("Index2", products.ToList());
        }

        public ActionResult SingleProduct(int id)
        {
            Session["Subcat"] = id;
            var products = db.Products.Include(p => p.Sub_Categories).Where(p => p.Product_id == id);
            return View(products.ToList());
        }
        public ActionResult search(String Search)
        {
            int id = 0;
            if (Session["Subcat"] != null)
            {
                id = int.Parse(Session["Subcat"].ToString());
            }
            var products = db.Products.Include(p => p.Sub_Categories).Where(p => p.Product_Name.Contains(Search));
            if (id != 0)
            {
                products = db.Products.Include(p => p.Sub_Categories).Where(p => p.Product_id == id && p.Product_Name.Contains(Search));
            }
            return View("Index2", products.ToList());

        }


      

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_id,Product_Name,Product_Image,Product_Size,Product_Color,Product_Price,Quantity,Product_Description,Subcategory_id,Water_needed")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Subcategory_id = new SelectList(db.Sub_Categories, "SubCategory_id", "SubCategoryName", products.Subcategory_id);
            return View(products);
        }
        [Authorize]
        public ActionResult Add_ToCart(int id=1, int quantity = 1)
        {
            cart Cart = new cart();

            Cart.Product_id = id;
            Cart.Quantity = quantity;
            var userId = User.Identity.GetUserId();
            Cart.userId = userId;
            db.cart.Add(Cart);
            db.SaveChanges();
            Session["NumberofItem"] = db.cart.Where(user => user.userId == userId).Count();
            return RedirectToAction("ViewCart", "Products");


        }
        public ActionResult Remove_FromCard(int id)
        {

            cart Cart = db.cart.Find(id);
            db.cart.Remove(Cart);
            db.SaveChanges();
            var userid = User.Identity.GetUserId();
            var Usercart = db.cart.Where(user => user.userId == userid);
            int Numberitem = 0;
            foreach (var item in Usercart)
            {
                Numberitem++;
            }
            Session["NumberofItem"] = Numberitem;
            return RedirectToAction("ViewCart", "Products");
        }
        [HttpPost]
        public ActionResult UpdateCart(FormCollection form)
        {
            var userid = User.Identity.GetUserId();
            var Usercart = db.cart.Where(user => user.userId == userid);
            int Numberitem = 0;
            foreach (var item in Usercart)
            {
                Numberitem++;
            }
            Session["NumberofItem"] = Numberitem;
            foreach (var key in form.AllKeys)
            {
                if (key.StartsWith("quantity-"))
                {
                    int cartItemId = int.Parse(key.Replace("quantity-", ""));
                    int quantity = int.Parse(form[key]);
                    var cartItem = db.cart.Find(cartItemId);
                    if (cartItem != null)
                    {
                        cartItem.Quantity = quantity;
                    }
                }
            }

            db.SaveChanges();

            return RedirectToAction("ViewCart");
        }

        public ActionResult ViewCart()
        {

            var userId = User.Identity.GetUserId();
            var user_Cart = db.cart.Where(user => user.userId == userId);
            float Totalprice = 0;
            foreach (var item in user_Cart)
            {
                float itemPrice = float.Parse(item.Products.Product_Price.ToString());
                int numberITem = int.Parse(item.Quantity.ToString());
                Totalprice += itemPrice * numberITem;
            }
            ViewBag.TotalPrice = Totalprice;

            return View(user_Cart.ToList());

        }



        // GET: Products/Details/5
       

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.Subcategory_id = new SelectList(db.Sub_Categories, "SubCategory_id", "SubCategoryName", products.Subcategory_id);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_id,Product_Name,Product_Image,Product_Size,Product_Color,Product_Price,Quantity,Product_Description,Subcategory_id,Water_needed")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Subcategory_id = new SelectList(db.Sub_Categories, "SubCategory_id", "SubCategoryName", products.Subcategory_id);
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
