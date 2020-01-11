using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantOrderApp.Models
{
    public class ValidationIsMealSelectedInOrder: ValidationAttribute
    {
        //var 
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var meal = (Meal)validationContext.ObjectInstance;
            return (meal.Name == "")
               ? new ValidationResult("Please select the meal") 
               : ValidationResult.Success;
        }
    }
}