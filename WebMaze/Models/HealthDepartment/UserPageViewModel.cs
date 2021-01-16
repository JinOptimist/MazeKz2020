using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.Models.Account;

namespace WebMaze.Models.HealthDepartment
{
    public class UserPageViewModel
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime StartPeriod { get; set; }
        public DateTime EndPeriod { get; set; }
        public string Type { get; set; }
        public long OwnerId { get; set; }

        public MedicalInsuranceViewModel Insurance { get; set; }
        public List<RecordFormViewModel> RecordForms { get; set; }
    }
}
