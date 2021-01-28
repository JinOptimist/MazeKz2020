using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Medicine;
using WebMaze.Models.Account;

namespace WebMaze.Models.HealthDepartment
{
    public class UserPageViewModel
    {
        public long Id { get; set; }
        public virtual string ReturnUrl { get; set; }
       
        public MedicalInsuranceViewModel MedicalInsurance { get; set; }
        
        public List<RecordFormViewModel> RecordForms { get; set; }
        public List<ReceptionOfPatientsViewModel> DoctorsAppointments { get; set; }
        public virtual long EnrolledCitizenId { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string MedicineDepartment { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string PrimarySymptoms { get; set; }

    }
}
