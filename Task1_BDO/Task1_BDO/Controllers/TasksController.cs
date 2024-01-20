using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task1_BDO.Models;

namespace Task1_BDO.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private BDO_TaskEntities db = new BDO_TaskEntities();

        // GET: Tasks
        public ActionResult Index(int id)
        {

            var tasks = db.Tasks.Include(t => t.Projects).Include(p => p.Timesheets).Where(p => p.Project_Id == id);
            TempData["ProjextId"] = id;

            return View(tasks.ToList());

        }


        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.Project_Id = new SelectList(db.Projects, "Project_Id", "Project_Name");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Task_Id,Project_Id,Task_Name,Task_Description,Start_Date,End_Data")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(tasks);
                db.SaveChanges();

                var timeSheet = new Timesheets();
                timeSheet.Task_Id = tasks.Task_Id;
                db.Timesheets.Add(timeSheet);
                db.SaveChanges();

                return RedirectToAction("Index", "Tasks", new { id = tasks.Project_Id });
            }

            ViewBag.Project_Id = new SelectList(db.Projects, "Project_Id", "Project_Name", tasks.Project_Id);
            return View(tasks);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            ViewBag.Project_Id = new SelectList(db.Projects, "Project_Id", "Project_Name", tasks.Project_Id);
            return View(tasks);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Task_Id,Project_Id,Task_Name,Task_Description,Start_Date,End_Data")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Project_Id = new SelectList(db.Projects, "Project_Id", "Project_Name", tasks.Project_Id);
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tasks tasks = db.Tasks.Find(id);
            db.Tasks.Remove(tasks);
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
