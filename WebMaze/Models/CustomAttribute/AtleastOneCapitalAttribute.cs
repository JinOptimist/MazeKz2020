using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.CustomAttribute
{
    public class AtleastOneCapitalAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return string.IsNullOrEmpty(ErrorMessage)
                ? $"{name} must has at least one capital letter"
                : ErrorMessage;
        }

        public override bool IsValid(object value)
        {
            if (value != null && !(value is string))
            {
                throw new Exception("StrongPasswordAttribute must be applied only for string fields");
            }

            if (value == null)
            {
                return false;
            }

            var str = (string)value;
            //Check that password has at least one capital letter
            return str.ToLower() != str;
        }
    }
}
