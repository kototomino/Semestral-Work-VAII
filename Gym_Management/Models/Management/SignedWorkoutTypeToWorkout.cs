using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym_Management.Models.Management
{
    public class SignedWorkoutTypeToWorkout
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int WorkoutId { get; set; }
        [Required]
        public int WorkoutTypeId { get; set; }
    }
}