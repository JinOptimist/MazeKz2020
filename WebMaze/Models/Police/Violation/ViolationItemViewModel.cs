using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Police.Violation
{
    public class ViolationItemViewModel
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string PolicemanName { get; set; }

        public DateTime Date { get; set; }
    }
}
