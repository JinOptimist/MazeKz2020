using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Repository;

namespace WebMaze.Models.CustomAttribute
{
    public class CheckOwnerIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && !(value is long))
            {
                throw new Exception("CheckOwnerIdAttribute must be applied only for long fields");
            }

            if (value == null)
            {
                return new ValidationResult("Value can't be null");
            }


            var id = (long)value;

            var userRepo = validationContext.GetService(typeof(CitizenUserRepository))
                as CitizenUserRepository;
            var existingId = userRepo.Get(id);
            if(existingId == null)
            {
                return new ValidationResult($"Пользователь с Id номер:{id} не существует.");
            }

            return ValidationResult.Success;
        }
    }
}
