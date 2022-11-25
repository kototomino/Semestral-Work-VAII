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
            this.PrepareWorkoutTypes();
            return View(db.Workouts.ToList());
        }
        private void PrepareCustomers()
        {
            var signedList = db.CustomersOnWorkouts.ToList();
            var customers = db.Customers.ToList();
            var workouts = db.Workouts.ToList();
            var list = new List<Customer_Workout>();
            foreach (var item in signedList)
            {
                var workout = workouts.Where(i => i.Id == item.WorkoutId).SingleOrDefault();
                var customer = customers.Where(i => i.Id == item.CustomerId).SingleOrDefault();
                if (customer != null)
                {
                    if (!customers.Contains(customer))
                    {
                        var CustomerOnWorkout = new Customer_Workout()
                        {
                            CustomerId = customer.Id,
                            Customer = customer,
                            WorkoutId = workout.Id,
                            Workout = workout

                        };
                        list.Add(CustomerOnWorkout);
                        workout.Customer_Workouts = list;
                    }
                }

            }
            db.SaveChanges();

            //var customer = db.Customers.Where(x => x.Id == signed.CustomerId).FirstOrDefault();
            //db.Workouts.FirstOrDefault().Customers.Add(customer);
        }
        private void PrepareWorkoutTypes()
        {
            var wtypes = db.WorkoutTypes.ToList();
            var workouts = db.Workouts.ToList();
            foreach (var item in workouts)
            {

                var wtype = wtypes.Where(i => i.Id == item.WorkoutTypeId).SingleOrDefault();
                if (wtype != null)
                {
                    item.WorkoutType = wtype;
                }

            }

        }
        private void PrepareCoach()
        {
            var coaches = db.Coaches.ToList();
            var workouts = db.Workouts.ToList();
            foreach (var item in workouts)
            {

                var coach = coaches.Where(i => i.Id == item.CoachId).SingleOrDefault();
                if (coach != null)
                {
                    item.Coach = coach;
                }

            }
        }
        // GET: Workout/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            this.PrepareCoach();
            this.PrepareCustomers();
            this.PrepareWorkoutTypes();
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        public ActionResult SignOutCustomer(int id)
        {
            this.PrepareCustomers();
            var userName = User.Identity.Name;
            var customer = db.Customers.ToList().Where(x => x.Email == userName).SingleOrDefault();
            var workout = db.Workouts.Find(id);
            var customerToWorkout = db.CustomersOnWorkouts;
            var CustomerOnWorkout = new Customer_Workout()
            {
                CustomerId = customer.Id,
                Customer = customer,
                WorkoutId = workout.Id,
                Workout = workout
            };
            var check = workout.Customer_Workouts.Where(x => x.CustomerId == customer.Id && x.WorkoutId == workout.Id).SingleOrDefault();
            var check2 = customerToWorkout.Where(x => x.CustomerId == customer.Id && x.WorkoutId == workout.Id).SingleOrDefault();
            if (check != check2)
            {
                return RedirectToAction("Index", db.Workouts.ToList());
            }
            else
            {
                var signedCustomerToWorkout = customerToWorkout.Where(x => x.CustomerId == customer.Id && x.WorkoutId == workout.Id).FirstOrDefault();
                if (signedCustomerToWorkout != null)
                {
                    workout.Capacity++;
                    workout.Customer_Workouts.Remove(CustomerOnWorkout);
                    customerToWorkout.Remove(signedCustomerToWorkout);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", db.Workouts.ToList());
        }
        public ActionResult SignCustomer(int id)
        {
            this.PrepareCustomers();
            var userName = User.Identity.Name;
            var customer = db.Customers.ToList().Where(x => x.Email == userName).SingleOrDefault();
            var workout = db.Workouts.Find(id);
            var customerToWorkout = db.CustomersOnWorkouts;
            var CustomerOnWorkout = new Customer_Workout()
            {
                CustomerId = customer.Id,
                Customer = customer,
                WorkoutId = workout.Id,
                Workout = workout
            };
            var check = workout.Customer_Workouts.Where(x => x.CustomerId == customer.Id && x.WorkoutId == workout.Id).SingleOrDefault();
            var check2 = customerToWorkout.Where(x => x.CustomerId == customer.Id && x.WorkoutId == workout.Id).SingleOrDefault();
            if (check == check2 && check != null && check2 != null)
            {
                return RedirectToAction("Index", db.Workouts.ToList());
            }
            else
            {
                if (workout.Capacity != 0)
                {
                    workout.Capacity--;
                    workout.Customer_Workouts.Add(CustomerOnWorkout);
                    customerToWorkout.Add(CustomerOnWorkout);
                    db.SaveChanges();
                }
            }

            //workout.Customers.Add(customer);

            return RedirectToAction("Index", db.Workouts.ToList());
        }
        // GET: Workout/Create
        public ActionResult Create()
        {
            var model = this.SetViewModel();
            return View(model);
        }
        private WorkoutViewModel SetViewModel()
        {
            WorkoutViewModel model = new WorkoutViewModel();

            model.CoachesSelectList = db.Coaches.ToList();
            model.WorkoutTypesSelectList = db.WorkoutTypes.ToList();
            return model;
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
                var coach = db.Coaches.Where(x => x.Id == workout.CoachId).SingleOrDefault();
                var wtype = db.WorkoutTypes.Where(x => x.Id == workout.WorkoutTypeId).SingleOrDefault();
                workout.Coach = coach;
                workout.WorkoutType = wtype;
                db.Workouts.Add(workout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            WorkoutViewModel model = new WorkoutViewModel();

            model.CoachesSelectList = db.Coaches.ToList();
            model.WorkoutTypesSelectList = db.WorkoutTypes.ToList();
            model.Workout = workout;
            return View(model);
        }

        // GET: Workout/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = SetViewModel();
            model.Workout = db.Workouts.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Workout/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Workout workout)
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
            //var signedCustomers = db.SignedCustomerToWorkouts.Where(x => x.WorkoutId == id).FirstOrDefault();
            //var customer = db.Customers.ToList().Where(x => x.Id == id).SingleOrDefault();

            //var signedCoach = db.SignedCoachToWorkouts.Where(x => x.WorkoutId == id).FirstOrDefault();
            //var signedWorkoutType = db.SignedWorkoutTypeToWorkouts.Where(x => x.WorkoutId == id).FirstOrDefault();
            //if (signedCustomers != null)
            //{
            //    db.SignedCustomerToWorkouts.Remove(signedCustomers);
            //}
            //if (signedCoach != null)
            //{
            //    db.SignedCoachToWorkouts.Remove(signedCoach);
            //}
            //if (signedWorkoutType != null)
            //{
            //    db.SignedWorkoutTypeToWorkouts.Remove(signedWorkoutType);
            //}
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
