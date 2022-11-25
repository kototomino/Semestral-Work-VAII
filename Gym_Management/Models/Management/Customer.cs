using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Gym_Management.Validators;

namespace Gym_Management.Models.Management
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        //public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Surname")]
        public string SurName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [MinimalAge15Customer]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //public ICollection<Workout> Workouts { get; set; } = new HashSet<Workout>();
        public ICollection<Customer_Workout> Customer_Workouts { get; set; } = new HashSet<Customer_Workout>();
    }
}