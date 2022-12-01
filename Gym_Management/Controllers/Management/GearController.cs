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
            if (User.IsInRole(Constants.Roles.Admin))
            {
                return View();
            } else
            {
                return View("IndexCustomer");
            }
            
        }

        public ActionResult GetGearPartial(int? id)
        {
            var gear = db.Gear.Find(id) ?? new Gear();
            return PartialView("_CreateOrUpdate", gear);
        }

        [Authorize(Roles = Constants.Roles.Admin)]
        public ActionResult DeleteGear(int id)
        {
            try
            {
                var gear = db.Gear.Find(id);
                db.Gear.Remove(gear);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }
            
        }
        [Authorize(Roles = Constants.Roles.Admin)]
        public ActionResult CreateOrUpdate(Gear gear)
        {
            if (ModelState.IsValid)
            {
                if (gear.Id > 0)
                {
                    db.Entry(gear).State = EntityState.Modified;
                }
                else
                {
                    db.Gear.Add(gear);
                }

                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllGear()
        {
            var gear = db.Gear.ToList();
            return Json(new { data = gear }, JsonRequestBehavior.AllowGet);
        }
        // GET: Gear/AddOrEdit/5
        [Authorize(Roles = Constants.Roles.Admin)]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                Gear gear = db.Gear.Find(id);
                if (gear == null)
                {
                    return HttpNotFound();
                }
                return View(gear);
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
