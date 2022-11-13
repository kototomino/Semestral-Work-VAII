using Gym_Management.Models.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym_Management.Validators
{
    public class MinimalAge18Coach : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var coach = (Coach)validationContext.ObjectInstance;
            var age = DateTime.Today.Year - coach.DateOfBirth.Year;
            return (age >= Constants.Constants.MinimalAgeCoach &&
                age <= Constants.Constants.MaximalAgePerson) ?
                ValidationResult.Success :
                new ValidationResult("Coach should be at least 18 and less than 90 years old");
        }
    }
}