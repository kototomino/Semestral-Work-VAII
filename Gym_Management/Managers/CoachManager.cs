using Gym_Management.Models;
using Gym_Management.Models.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym_Management.Managers
{
    public class CoachManager
    {
        private ApplicationDbContext Context { get; }
        public CoachManager()
        {
            Context = new ApplicationDbContext();
        }
        
        public List<Coach> GetCoaches()
        {
            var coaches = Context.Coaches.ToList();
            Context.Dispose();
            return coaches;
        }
    }
}