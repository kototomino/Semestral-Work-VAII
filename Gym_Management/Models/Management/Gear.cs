using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym_Management.Models.Management
{
    public class Gear
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal? Quantity { get; set; }
        [StringLength(20)]
        public string GearType { get; set; }
    }
}