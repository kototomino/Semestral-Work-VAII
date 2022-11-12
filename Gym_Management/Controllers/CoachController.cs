using Gym_Management.Managers;
using Gym_Management.Models.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gym_Management.Controllers
{
    [AllowAnonymous]
    public class CoachController : Controller
    {
        private CoachManager CoachManager { get; }
        public CoachController()
        {
            CoachManager = new CoachManager();
        }
        // GET: Coach
        public ActionResult Index()
        {
            var list = this.CoachManager.GetCoaches();
            return View(list);
        }
        public ActionResult Details(int id)
        {
            var coach = this.CoachManager.GetCoaches().SingleOrDefault(c => c.Id == id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }
        public ActionResult Edit(int id)
        {
            var coach = this.CoachManager.GetCoaches().SingleOrDefault(c => c.Id == id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}