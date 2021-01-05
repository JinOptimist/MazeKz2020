using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.Account;

namespace WebMaze.Models.CustomAttribute
{
    public class UniqUserNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && !(value is string))
            {
                throw new Exception("StrongPasswordAttribute must be applied only for string fields");
            }

            if (value == null)
            {
                return new ValidationResult("Value can't be null");
            }

            var login = (string)value;

            var userRepository = validationContext.GetService(typeof(CitizenUserRepository)) 
                as CitizenUserRepository;
            var existingUser = userRepository.GetUserByName(login);
            if (existingUser != null)
            {
                return new ValidationResult($"{login} is not uniq. There is user with the same name");
            }

            return ValidationResult.Success;
        }
    }
}
