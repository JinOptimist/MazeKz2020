using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model
{
    public class Bus : BaseModel
    {
        public virtual BusRoute BusRoute { get; set; }
        public long? BusRouteId { get; set; }
        public string RegistrationPlate { get; set; }
        public virtual BusWorker Worker { get; set; }
        public long? WorkerId { get; set; }
        public string BusModel { get; set; }
        public int Capacity { get; set; }

    }
}
