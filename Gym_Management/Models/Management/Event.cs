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
        public string Name { get; set; }
        [Required]
        public string StartDateTime { get; set; }
        [Required]
        public string EndDateTime { get; set; }
        public List<Coach> Coaches { get; set; }
    }
}