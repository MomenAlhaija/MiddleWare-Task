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
    public class TasksController : Controller
    {
        private BDO_TaskEntities2 db = new BDO_TaskEntities2();

        // GET: Tasks
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                var tasks = db.Tasks.Include(t => t.Projects).Include(p => p.TimeSheete).Where(p => p.Project_Id == id);
                TempData["ProjextId"] = id;
                return View(tasks.ToList());

            }
            else
            {
                return View();  

            }

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
        public ActionResult Create([Bind(Include = "Task_Id,Project_Id,Task_Name,Task_Description,Start_Date,End_Data")] Tasks tasks,string Hours)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tasks.Number_Hours = Convert.ToInt32(Hours);
                    db.Tasks.Add(tasks);
                    db.SaveChanges();

                    var timeSheet = new TimeSheete();
                    timeSheet.Task_Id = tasks.Task_Id;
                    db.TimeSheete.Add(timeSheet);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Tasks", new { id = tasks.Project_Id });
                }

                ViewBag.Project_Id = new SelectList(db.Projects, "Project_Id", "Project_Name", tasks.Project_Id);
                return View(tasks);
            }
            catch
            {
                return View("Index", "Projects");
            }
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            try
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
            catch
            {
                return View("Index", "Projects");
            }
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tasks tasks)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingTask = db.Tasks.Find(tasks.Task_Id);
                    if (existingTask != null)
                    {
                        existingTask.Task_Name = tasks.Task_Name;
                        existingTask.Task_Description = tasks.Task_Description;
                        existingTask.Start_Date = tasks.Start_Date;
                        existingTask.End_Data = tasks.End_Data;

                        db.SaveChanges();
                        return RedirectToAction("Index", "Tasks", new { id = existingTask.Project_Id });
                    }
                }

                ViewBag.Project_Id = new SelectList(db.Projects, "Project_Id", "Project_Name", tasks.Project_Id);
                return View(tasks);
            }
            catch
            {
                return View("Index", "Projects");
            }
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            try
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
            catch
            {
                return View("Index", "Projects");
            }
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                try
                {
                    Tasks tasks = db.Tasks.Find(id);
                    db.Tasks.Remove(tasks);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    Tasks tasks = db.Tasks.Find(id);
                    ViewBag.Error = "You Can Not Delete This Task";
                    return View(tasks);
                }
            }
            catch
            {
                return View("Index", "Projects");
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
