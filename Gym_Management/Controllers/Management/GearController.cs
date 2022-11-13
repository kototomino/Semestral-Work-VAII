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
    public class GearController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Gear
        public ActionResult Index()
        {
            return View(db.Gear.ToList());
        }

        // GET: Gear/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gear gear = db.Gear.Find(id);
            if (gear == null)
            {
                return HttpNotFound();
            }
            return View(gear);
        }

        // GET: Gear/Create
        [Authorize(Roles = Constants.Roles.Admin)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gear/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constants.Roles.Admin)]
        public ActionResult Create([Bind(Include = "Id,Name,Quantity,GearType")] Gear gear)
        {
            if (ModelState.IsValid)
            {
                db.Gear.Add(gear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gear);
        }

        // GET: Gear/Edit/5
        [Authorize(Roles = Constants.Roles.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gear gear = db.Gear.Find(id);
            if (gear == null)
            {
                return HttpNotFound();
            }
            return View(gear);
        }

        // POST: Gear/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constants.Roles.Admin)]
        public ActionResult Edit([Bind(Include = "Id,Name,Quantity,GearType")] Gear gear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gear);
        }

        // GET: Gear/Delete/5
        [Authorize(Roles = Constants.Roles.Admin)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gear gear = db.Gear.Find(id);
            if (gear == null)
            {
                return HttpNotFound();
            }
            return View(gear);
        }

        // POST: Gear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constants.Roles.Admin)]
        public ActionResult DeleteConfirmed(int id)
        {
            Gear gear = db.Gear.Find(id);
            db.Gear.Remove(gear);
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
