using Gym_Management.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym_Management.Models.Management
{
    public class Workout
    {
        [Key]
        public int Id { get; set; }
        //public int WorkoutId { get; set; }
        [Required]
        [StringLength(70)]
        public string Name { get; set; }
        
        [Display(Name = "Type")]
        public WorkoutType WorkoutType { get; set; }
        public int WorkoutTypeId { get; set; }
        [Required]
        [Display(Name = "From")]
        [WorkoutDateTimeValidationToFuture]
        public DateTime StartDateTime { get; set; }
        [Required]
        [Display(Name = "To")]
        [WorkoutDateTimeValidationToFuture]
        public DateTime EndDateTime { get; set; }
        public Coach Coach { get; set; }
        public int CoachId { get; set; }
        //public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        [Required]
        public decimal? Capacity { get; set; }
        [Display(Name = "Customers")]
        public ICollection<Customer_Workout> Customer_Workouts { get; set; } = new HashSet<Customer_Workout>();
    }
}