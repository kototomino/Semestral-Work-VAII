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
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string SurName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [MinimalAge15Customer]
        public DateTime DateOfBirth { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
    }
}