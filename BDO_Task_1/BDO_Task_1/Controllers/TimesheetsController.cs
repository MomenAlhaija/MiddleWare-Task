using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BDO_Task_1.Models;
using Microsoft.AspNet.Identity;

namespace BDO_Task_1.Controllers
{
    [Authorize(Roles ="Employee")]
    public class TimesheetsController : Controller
    {
        private BDO_TaskEntities db = new BDO_TaskEntities();

        // GET: Timesheets
        public ActionResult Index(int? id)
        {
            var timesheets = db.Timesheets.Include(t => t.AspNetUsers).Include(t => t.Tasks).Where(ts => ts.Task_Id == id);
            return View(timesheets.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Save(float NumberOfHours, string TaskName, int TaskId, int SheetId)
        {
            var TimeSheet = db.Timesheets.Include(t => t.AspNetUsers).Include(t => t.Tasks).Where(ts => ts.Sheet_Id == SheetId).FirstOrDefault();
            TimeSheet.Task_Id = TaskId;
            TimeSheet.Hours_Worked = NumberOfHours;
            TimeSheet.Employee_Id = User.Identity.GetUserId();
            TimeSheet.Status = 1;
            db.SaveChanges();
            return RedirectToAction("Index", "Tasks", new { id = TimeSheet.Tasks.Project_Id });
        }
        // GET: Timesheets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheets timesheets = db.Timesheets.Find(id);
            if (timesheets == null)
            {
                return HttpNotFound();
            }
            return View(timesheets);
        }

        // GET: Timesheets/Create
        public ActionResult Create()
        {
            ViewBag.Employee_Id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Task_Id = new SelectList(db.Tasks, "Task_Id", "Task_Name");
            return View();
        }

        // POST: Timesheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sheet_Id,Task_Id,Employee_Id,Status,Hours_Worked")] Timesheets timesheets)
        {
            if (ModelState.IsValid)
            {
                db.Timesheets.Add(timesheets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_Id = new SelectList(db.AspNetUsers, "Id", "Email", timesheets.Employee_Id);
            ViewBag.Task_Id = new SelectList(db.Tasks, "Task_Id", "Task_Name", timesheets.Task_Id);
            return View(timesheets);
        }

        // GET: Timesheets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheets timesheets = db.Timesheets.Find(id);
            if (timesheets == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_Id = new SelectList(db.AspNetUsers, "Id", "Email", timesheets.Employee_Id);
            ViewBag.Task_Id = new SelectList(db.Tasks, "Task_Id", "Task_Name", timesheets.Task_Id);
            return View(timesheets);
        }

        // POST: Timesheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sheet_Id,Task_Id,Employee_Id,Status,Hours_Worked")] Timesheets timesheets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timesheets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_Id = new SelectList(db.AspNetUsers, "Id", "Email", timesheets.Employee_Id);
            ViewBag.Task_Id = new SelectList(db.Tasks, "Task_Id", "Task_Name", timesheets.Task_Id);
            return View(timesheets);
        }

        // GET: Timesheets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheets timesheets = db.Timesheets.Find(id);
            if (timesheets == null)
            {
                return HttpNotFound();
            }
            return View(timesheets);
        }

        // POST: Timesheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Timesheets timesheets = db.Timesheets.Find(id);
            db.Timesheets.Remove(timesheets);
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
