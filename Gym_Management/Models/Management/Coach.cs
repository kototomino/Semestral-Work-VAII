using Gym_Management.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym_Management.Models.Management
{
    public class Coach
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Surname")]
        public string SurName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [MinimalAge18Coach]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Range(1,99)]
        [Display(Name = "Skill Degree")]
        public int SkillDegree { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
    }
}