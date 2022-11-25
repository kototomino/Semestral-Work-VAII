using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Gym_Management.Models.Management
{
    public class Customer_Workout
    {  
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
    }
}