using System;

namespace WebMaze.DbStuff.Model.Police
{
    public class Violation : BaseModel
    {
        public CitizenUser User { get; set; }
        
        public Policeman BlamingPoliceman { get; set; }
        
        public ViolationType TypeOfViolation { get; set; }
        
        public DateTime Date { get; set; }
    }
}
