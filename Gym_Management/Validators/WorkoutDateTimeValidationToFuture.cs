using Gym_Management.Models.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym_Management.Validators
{
    public class WorkoutDateTimeValidationToFuture : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var workout = (Workout)validationContext.ObjectInstance;
            var dateFrom = workout.StartDateTime;
            var dateTo = workout.EndDateTime;
            var dateNow = DateTime.Now;
            return (dateFrom >= dateNow &&
                dateTo >= dateNow) ?
                ValidationResult.Success :
                new ValidationResult("Planned workout needs to be in future");
        }
    }
}