using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.Models.Bus;

namespace WebMaze.Models.CustomAttribute
{
    public class BusOrderTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var busOrderViewModel = validationContext.ObjectInstance as BusOrderViewModel;

            if(value==null)
            {
                return new ValidationResult("Value must not be null");
            }

            if((busOrderViewModel.TargetedDate-busOrderViewModel.OrderDate).Days<3)
            {
                return new ValidationResult("The order must be made at least 3 days in advance");
            }
            return ValidationResult.Success;
        }
    }
}
