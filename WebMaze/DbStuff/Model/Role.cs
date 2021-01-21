using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model
{
    public class Role : BaseModel
    {
        public virtual string Name { get; set; }

        public virtual List<CitizenUser> Users { get; set; }
    }
}
