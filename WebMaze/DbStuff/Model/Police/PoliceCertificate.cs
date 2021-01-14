using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Police
{
    public class PoliceCertificate : BaseModel
    {
        public string Speciality { get; set; }
        
        public DateTime DateOfIssue { get; set; }

        public DateTime? Validity { get; set; }

        public virtual List<CitizenUser> User { get; set; }
    }
}
