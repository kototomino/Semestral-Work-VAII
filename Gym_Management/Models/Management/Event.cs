using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym_Management.Models.Management
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "From")]
        public DateTime StartDateTime { get; set; }
        [Required]
        [Display(Name = "To")]
        public DateTime EndDateTime { get; set; }
        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}