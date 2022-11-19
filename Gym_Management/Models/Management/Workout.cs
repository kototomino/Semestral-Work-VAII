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
        [Required]
        [StringLength(70)]
        public string Name { get; set; }
        
        [Display(Name = "Type")]
        public WorkoutType WorkoutType { get; set; }
        [Required]
        [Display(Name = "From")]
        public DateTime StartDateTime { get; set; }
        [Required]
        [Display(Name = "To")]
        public DateTime EndDateTime { get; set; }
        public Coach Coach { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public decimal? Capacity { get; set; }
    }
}