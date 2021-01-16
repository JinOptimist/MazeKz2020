using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.CustomAttribute
{
    public class CheckEndDateAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return string.IsNullOrEmpty(ErrorMessage)
                ? $"{name} Необходимо установить дату больше сегодняшней"
                : ErrorMessage;
        }

        public override bool IsValid(object value)
        {
            if (value != null && !(value is DateTime))
            {
                throw new Exception("CheckStartDataAttribute must be applied only for DateTime fields");
            }

            if (value == null)
            {
                return false;
            }

            var date = (DateTime)value;
            var dateNow = DateTime.Today;
            var check = date.CompareTo(dateNow);
            if (check != 1)
            {
                return false;
            }

            return true;
        }
    }
}
