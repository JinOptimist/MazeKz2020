using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Medicine
{
    public class MedicalInsurance : BaseModel
    {
        public virtual long OwnerId { get; set; }
        public virtual CitizenUser Owner { get; set; }
        public virtual bool IsMaried { get; set; }
        public virtual bool HaveChildren { get; set; }
        public virtual DateTime StartPeriod { get; set; }
        public virtual DateTime EndPeriod { get; set; }
        public virtual string Type { get; set; }
        public virtual decimal Coast { get; set; }

        

        
    }
}
