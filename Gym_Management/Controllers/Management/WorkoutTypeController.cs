using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gym_Management.Models;
using Gym_Management.Models.Management;

namespace Gym_Management.Controllers.Management
{
    public class WorkoutTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkoutType
        public ActionResult Index()
        {
            return View(db.WorkoutTypes.ToList());
        }

        // GET: WorkoutType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutType workoutType = db.WorkoutTypes.Find(id);
            if (workoutType == null)
            {
                return HttpNotFound();
            }
            return View(workoutType);
        }

        // GET: WorkoutType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkoutType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] WorkoutType workoutType)
        {
            if (ModelState.IsValid)
            {
                db.WorkoutTypes.Add(workoutType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workoutType);
        }

        // GET: WorkoutType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutType workoutType = db.WorkoutTypes.Find(id);
            if (workoutType == null)
            {
                return HttpNotFound();
            }
            return View(workoutType);
        }

        // POST: WorkoutType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] WorkoutType workoutType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workoutType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workoutType);
        }

        // GET: WorkoutType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutType workoutType = db.WorkoutTypes.Find(id);
            if (workoutType == null)
            {
                return HttpNotFound();
            }
            return View(workoutType);
        }

        // POST: WorkoutType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkoutType workoutType = db.WorkoutTypes.Find(id);
            db.WorkoutTypes.Remove(workoutType);
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
