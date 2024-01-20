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
    public class TimeSheetesController : Controller
    {
        private BDO_TaskEntities2 db = new BDO_TaskEntities2();

        // GET: TimeSheetes
        public ActionResult Index(int id)
        {
            try
            {
                var timeSheete = db.TimeSheete.Include(t => t.Tasks).Where(ts => ts.Task_Id == id).FirstOrDefault();
                return View(timeSheete);
            }
            catch {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Save(float NumberOfHours, string TaskName, int TaskId, int SheetId)
        {
            try
            {
                var TimeSheet = db.TimeSheete.Include(t => t.Tasks).Where(ts => ts.Sheet_Id == SheetId).FirstOrDefault();
                TimeSheet.Task_Id = TaskId;
                TimeSheet.Hours_Worked = NumberOfHours;
                TimeSheet.Tasks.Employee_Id = User.Identity.GetUserId();
                TimeSheet.Tasks.Task_Status = 1;
                db.SaveChanges();
                return RedirectToAction("Index", "Tasks", new { id = TimeSheet.Tasks.Project_Id });
            }
            catch
            {
                return View("Index", "Projects");
            }
        }
        

        // GET: TimeSheetes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheete timeSheete = db.TimeSheete.Find(id);
            if (timeSheete == null)
            {
                return HttpNotFound();
            }
            return View(timeSheete);
        }

        // GET: TimeSheetes/Create
        public ActionResult Create()
        {
            ViewBag.Task_Id = new SelectList(db.Tasks, "Task_Id", "Task_Name");
            return View();
        }

        // POST: TimeSheetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sheet_Id,Task_Id,Hours_Worked")] TimeSheete timeSheete)
        {
            if (ModelState.IsValid)
            {
                db.TimeSheete.Add(timeSheete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Task_Id = new SelectList(db.Tasks, "Task_Id", "Task_Name", timeSheete.Task_Id);
            return View(timeSheete);
        }

        // GET: TimeSheetes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheete timeSheete = db.TimeSheete.Find(id);
            if (timeSheete == null)
            {
                return HttpNotFound();
            }
            ViewBag.Task_Id = new SelectList(db.Tasks, "Task_Id", "Task_Name", timeSheete.Task_Id);
            return View(timeSheete);
        }

        // POST: TimeSheetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sheet_Id,Task_Id,Hours_Worked")] TimeSheete timeSheete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeSheete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Task_Id = new SelectList(db.Tasks, "Task_Id", "Task_Name", timeSheete.Task_Id);
            return View(timeSheete);
        }

        // GET: TimeSheetes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheete timeSheete = db.TimeSheete.Find(id);
            if (timeSheete == null)
            {
                return HttpNotFound();
            }
            return View(timeSheete);
        }

        // POST: TimeSheetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeSheete timeSheete = db.TimeSheete.Find(id);
            db.TimeSheete.Remove(timeSheete);
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
