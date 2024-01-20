
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskBDO.Models;

namespace TaskBDO.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private BDO_TaskEntities2 db = new BDO_TaskEntities2();

        // GET: Projects
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();
            var projects = db.Projects.Include(p => p.AspNetUsers).ToList();
            if (!User.IsInRole("Employee")){
                 projects = db.Projects.Include(p => p.AspNetUsers).Where(u => u.User_Id == userId).ToList();
            }
         

          return View(projects);
        }


        // GET: Projects/Create
        public ActionResult Create()
        {
            ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Project_Id,Project_Name,Project_Description,User_Id")] Projects projects,string Housrs)
        {
            if (ModelState.IsValid)
            {

                projects.User_Id = User.Identity.GetUserId();
                projects.Number_Hours=float.Parse(Housrs);
                db.Projects.Add(projects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email", projects.User_Id);
            return View(projects);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email", projects.User_Id);
            return View(projects);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Project_Id,Project_Name,Project_Description,User_Id")] Projects projects)
        {
            if (ModelState.IsValid)
            {
                projects.User_Id = User.Identity.GetUserId();
                db.Entry(projects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email", projects.User_Id);
            return View(projects);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = db.Projects.Find(id);
            if (projects == null)
            {
                return HttpNotFound();
            }
            return View(projects);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Projects projects = db.Projects.Find(id);
                db.Projects.Remove(projects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error="Error!!!...The Project Contain One or More From The Tasks";
                return View();
            }

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
