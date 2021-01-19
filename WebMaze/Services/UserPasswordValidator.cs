using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebMaze.Services
{
    public class UserPasswordValidator
    {
        public int RequiredLength { get; set; } = 3;

        public UserPasswordValidator(int requiredLength)
        {
            RequiredLength = requiredLength;
        }
 
        public bool Validate(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < RequiredLength)
            {
                return false;
            }

            var patterns = new List<string>
            {
                @"[0-9]"
            };

            foreach (var pattern in patterns)
            {
                if (!Regex.IsMatch(password, pattern))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
