using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.HealthDepartment
{
    public class ReceptionOfPatientsViewModel
    {
        public virtual long Id { get; set; }
        public virtual long EnrolledCitizenId { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual string PrimarySymptoms { get; set; }
        public virtual string MedicineDepartment { get; set; }

    }
}
