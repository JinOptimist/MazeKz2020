using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Police
{
    public class ViolationType : BaseModel
    {
        public virtual List<Violation> Violations { get; set; }

        public string Article { get; set; }

        public string Punishment { get; set; }

        public DateTime? TermOfPunishment { get; set; }
        
        [Column(TypeName = "money")]
        public decimal? Penalty { get; set; }
    }
}
