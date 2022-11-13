using Gym_Management.Models.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gym_Management.Validators
{
    public class MinimalAge15Customer : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            var age = DateTime.Today.Year - customer.DateOfBirth.Year;
            return (age >= Constants.Constants.MinimalAgeCustomer &&
                age <= Constants.Constants.MaximalAgePerson) ?
                ValidationResult.Success :
                new ValidationResult("Customer should be at least 15 and less than 90 years old");
        }
    }
}