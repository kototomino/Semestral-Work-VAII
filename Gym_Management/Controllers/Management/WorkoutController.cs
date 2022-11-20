using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Gym_Management.Models;
using Gym_Management.Models.Management;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.VisualBasic.ApplicationServices;

namespace Gym_Management.Controllers.Management
{
    public class WorkoutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Workout
        public ActionResult Index()
        {
            this.PrepareCoach();
            this.PrepareCustomers();
            return View(db.Workouts.ToList());
        }
        private void PrepareCustomers()
        {
            var signedList = db.SignedCustomerToWorkouts.ToList();
            var customers = db.Customers.ToList();
            var workouts = db.Workouts.ToList();
            foreach (var item in signedList)
            {
                var workout = workouts.Where(i => i.Id == item.WorkoutId).FirstOrDefault();
                var customer = customers.Where(i => i.Id == item.CustomerId).FirstOrDefault();
                if (customer != null)
                {
                    workout.Customers.Add(customer);
                }

            }

            //var customer = db.Customers.Where(x => x.Id == signed.CustomerId).FirstOrDefault();
            //db.Workouts.FirstOrDefault().Customers.Add(customer);
        }
        private void PrepareCoach()
        {

            var coach = db.Coaches.Where(x => x.Id == db.Workouts.FirstOrDefault().CoachId).ToList().FirstOrDefault();
            if (coach != null)
            {
                db.Workouts.FirstOrDefault().Coach = coach;
            }
        }
        // GET: Workout/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        public ActionResult SignOutCustomer(int id)
        {
            var userName = User.Identity.Name;
            var customer = db.Customers.ToList().Where(x => x.Email == userName).FirstOrDefault();
            var workout = db.Workouts.Find(id);
            var signed = db.SignedCustomerToWorkouts;
            var signedCustomerToWorkout = signed.Where(x => x.CustomerId == customer.Id && x.WorkoutId == workout.Id).FirstOrDefault();
            if (signedCustomerToWorkout != null)
            {
                workout.Capacity++;
                signed.Remove(signedCustomerToWorkout);
                db.SaveChanges();
            }

            return RedirectToAction("Index", db.Workouts.ToList());
        }
        public ActionResult SignCustomer(int id)
        {
            var userName = User.Identity.Name;
            var customer = db.Customers.ToList().Where(x => x.Email == userName).FirstOrDefault();
            var workout = db.Workouts.Find(id);
            SignedCustomerToWorkout signedCustomerToWorkout = new SignedCustomerToWorkout() { CustomerId = customer.Id, WorkoutId = workout.Id };
            var signed = db.SignedCustomerToWorkouts;
            if (workout.Capacity != 0)
            {
                workout.Capacity--;
                signed.Add(signedCustomerToWorkout);
                db.SaveChanges();
            }

            //workout.Customers.Add(customer);

            return RedirectToAction("Index", db.Workouts.ToList());
        }
        // GET: Workout/Create
        public ActionResult Create()
        {
            WorkoutViewModel model = new WorkoutViewModel();

            //model.CoachesSelectList.Add(new SelectListItem { Text = "Shyju", Value = "11" });

            model.CoachesSelectList = db.Coaches.ToList();
            return View(model);
        }

        // POST: Workout/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Workout workout)
        {
            if (ModelState.IsValid)
            {
                var coach = db.Coaches.Where(x => x.Id == workout.CoachId).FirstOrDefault();
                workout.Coach = coach;
                db.Workouts.Add(workout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workout);
        }

        // GET: Workout/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // POST: Workout/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StartDateTime,EndDateTime,Capacity")] Workout workout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workout);
        }

        // GET: Workout/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        // POST: Workout/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var signed = db.SignedCustomerToWorkouts.Where(x => x.WorkoutId == id).FirstOrDefault();
            if (signed != null)
            {
                db.SignedCustomerToWorkouts.Remove(signed);
            }
            Workout workout = db.Workouts.Find(id);
            db.Workouts.Remove(workout);
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
