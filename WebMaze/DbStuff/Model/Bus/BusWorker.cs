using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model
{
    public class BusWorker : BaseModel
    {
        public string License { get; set; }
        public virtual Bus Bus { get; set; }

    }
}
