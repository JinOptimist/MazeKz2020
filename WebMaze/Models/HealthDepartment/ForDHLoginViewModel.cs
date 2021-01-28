using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.Models.CustomAttribute.Medecine;

namespace WebMaze.Models.HealthDepartment
{
    public class ForDHLoginViewModel
    {
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Gender { get; set; }

        public virtual string Email { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual bool IsDead { get; set; }
        public virtual bool Marriage { get; set; }
        public virtual bool HaveChildren { get; set; }
        public virtual decimal Balance { get; set; }

        public virtual DateTime BirthDate { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual string ReturnUrl { get; set; }
    }
}
