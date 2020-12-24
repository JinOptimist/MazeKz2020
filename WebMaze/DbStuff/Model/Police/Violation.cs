using System;

namespace WebMaze.DbStuff.Model.Police
{
    public class Violation : BaseModel
    {
        public virtual CitizenUser User { get; set; }
        
        public virtual Policeman BlamingPoliceman { get; set; }
        
        public virtual ViolationType TypeOfViolation { get; set; }
        
        public DateTime Date { get; set; }
    }
}
