using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.HealthDepartment
{
    public class ListRecordFormViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
