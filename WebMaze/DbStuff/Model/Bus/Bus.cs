using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model
{
    public class Bus : BaseModel
    {
        public long BusRouteId { get; set; }
        public BusRoute BusRoute { get; set; }

        public string RegistrationPlate { get; set; }

        public long WorkerId { get; set; }

        public int Capacity { get; set; }

    }
}
