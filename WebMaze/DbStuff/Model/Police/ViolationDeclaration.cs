using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Police
{
    public class ViolationDeclaration : BaseModel
    {
        [Required]
        public virtual CitizenUser User { get; set; }

        [Required]
        public virtual CitizenUser BlamedUser { get; set; }
        
        public virtual Policeman ViewedPoliceman { get; set; }
        
        public DateTime Date { get; set; }

        public string Explanation { get; set; }

        [Required]
        public string OffenseType { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
