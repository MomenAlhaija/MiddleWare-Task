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
    public class TransactionsController : Controller
    {
        private PlantsEntities db = new PlantsEntities();

        // GET: Transactions
      public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user_Cart = db.cart.Where(user => user.userId == userId);
            float TotalPrice = 0;
            foreach (var item in user_Cart)
            {
                float productPrice = float.Parse(Convert.ToString(item.Products.Product_Price));
                int NumberOfItems = int.Parse(Convert.ToString(item.Quantity));
                TotalPrice += productPrice * NumberOfItems;

            }
            ViewBag.TotalPrice = TotalPrice;
            return View(user_Cart.ToList());
        }

        public ActionResult MakeOrder()
        {
            Session["USerid"] =User.Identity.GetUserId();

            var userId = User.Identity.GetUserId();
            var cartItems = db.cart.Where(c => c.userId == userId).ToList();

            Orders order = new Orders
            {
                Order_id =Convert.ToString(Guid.NewGuid()),
                Order_date = DateTime.Now,
                userId = userId,

            };
            db.Orders.Add(order);
            db.SaveChanges();
            float TotalPrice = 0;
            foreach (var cartItem in cartItems)
                {
                var itemprice = cartItem.Products.Product_Price;
                var itemQuentity = cartItem.Quantity;
                TotalPrice +=float.Parse(Convert.ToString(itemprice * itemQuentity));
                Order_Details orderDetail = new Order_Details
                {

                        Order_id = order.Order_id,
                        Product_id = cartItem.Product_id,
                        Quantity = cartItem.Quantity,
                };
                    // Associate the OrderDetail objects with the Order object
                    db.Order_Details.Add(orderDetail);
                    // Remove the cart item from the Cart table
                    db.cart.Remove(cartItem);

                }
                Session["NumberofItem"] = 0;
                order.Total_price = TotalPrice;
                db.SaveChanges();
                return RedirectToAction("Index", "Transactions");
            

        }

        

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cart cart = db.cart.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Product_id = new SelectList(db.Products, "Product_id", "Product_Name");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cart_Id,Product_id,userId,Quantity")] cart cart)
        {
            if (ModelState.IsValid)
            {
                db.cart.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", cart.userId);
            ViewBag.Product_id = new SelectList(db.Products, "Product_id", "Product_Name", cart.Product_id);
            return View(cart);
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cart cart = db.cart.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", cart.userId);
            ViewBag.Product_id = new SelectList(db.Products, "Product_id", "Product_Name", cart.Product_id);
            return View(cart);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cart_Id,Product_id,userId,Quantity")] cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.AspNetUsers, "Id", "Email", cart.userId);
            ViewBag.Product_id = new SelectList(db.Products, "Product_id", "Product_Name", cart.Product_id);
            return View(cart);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cart cart = db.cart.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cart cart = db.cart.Find(id);
            db.cart.Remove(cart);
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
