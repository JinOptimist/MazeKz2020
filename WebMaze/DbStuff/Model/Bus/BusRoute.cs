using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model
{
    public class BusRoute : BaseModel
    {
        public string Route { get; set; }

        public virtual List<Bus> Buses { get; set; }

    }
}
