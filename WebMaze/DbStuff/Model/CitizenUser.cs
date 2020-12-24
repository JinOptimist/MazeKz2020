using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model
{
    public class CitizenUser : BaseModel
    {
        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual string AvatarUrl { get; set; }

        public virtual List<Adress> Adresses { get; set; }
    }
}
