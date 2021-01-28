using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMaze.DbStuff.Model.Police
{
    public class Violation : BaseModel
    {
        public virtual CitizenUser User { get; set; }
        
        public virtual Policeman BlamingPoliceman { get; set; }
        
        public DateTime Date { get; set; }

        public string Article { get; set; }

        public string Punishment { get; set; }

        public DateTime? TermOfPunishment { get; set; }

        [Column(TypeName = "money")]
        public decimal? Penalty { get; set; }
    }
}
