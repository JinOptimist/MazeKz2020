using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.CustomAttribute
{
    public class BusRouteLenghtAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Bus route must consist from at least 4 bus stops";
        }
        public override bool IsValid(object value)
        {
            if(value is null)
            {
                return false;
            }

            if (!(value is string))
            {
                throw new Exception("Attribute is only for string");
            }

            var str = value as string;

            return str.Count(x=>x == '-')>3;
        }
    }
}
