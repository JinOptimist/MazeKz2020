using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Police.Violation
{
    public class ViolationRegistrationViewModel
    {
        public string UserLogin { get; set; }
        public string PolicemanLogin { get; set; }
        public DateTime Date { get; set; }

        public string Article { get; set; }
        public string Punishment { get; set; }
        public DateTime? TermOfPunishment { get; set; }
        public decimal? Penalty { get; set; }
    }
}
