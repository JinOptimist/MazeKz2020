using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.Models.CustomAttribute;

namespace WebMaze.Models.HealthDepartment
{
    public class RecordFormViewModel
    {
        //[CheckOwnerId]
        public long CitizenId { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
