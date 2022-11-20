using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gym_Management.Models.Management
{
    public class WorkoutViewModel
    {
        public Workout Workout { get; set; }
        public IEnumerable<WorkoutType> WorkoutTypesSelectList { get; set; }
        public IEnumerable<Coach> CoachesSelectList { get; set; }
    }
}