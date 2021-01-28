using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model
{
    public class BusRouteTime : BaseModel
    {
        public string StartingPoint { get; set; }
        public string EndingPoint { get; set; }
        public int Minutes { get; set; }
    }
}
