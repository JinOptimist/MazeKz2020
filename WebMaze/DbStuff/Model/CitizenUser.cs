using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Medicine;
using WebMaze.DbStuff.Model.Police;
using WebMaze.DbStuff.Model.UserAccount;

namespace WebMaze.DbStuff.Model
{
    public class CitizenUser : BaseModel
    {
        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual string AvatarUrl { get; set; }

        public virtual bool IsBlocked { get; set; }

        public virtual decimal Balance { get; set; }

        public virtual DateTime RegistrationDate { get; set; }

        public virtual DateTime LastLoginDate { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Gender { get; set; }

        public virtual string Email { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual bool IsDead { get; set; }

        public virtual DateTime BirthDate { get; set; }

        public virtual bool Marriage { get; set; }

        public virtual bool HaveChildren { get; set; }

        public virtual List<Role> Roles { get; set; }

        public virtual List<Adress> Adresses { get; set; }

        public virtual List<PoliceCertificate> PoliceCertificates { get; set; }

        public virtual List<Certificate> Certificates { get; set; }

        public virtual MedicalInsurance MedicalInsurance { get; set; }
        public virtual List<RecordForm> RecordForms { get; set; }
        public virtual MedicineCertificate MedicineCertificate { get; set; }
    }
}
