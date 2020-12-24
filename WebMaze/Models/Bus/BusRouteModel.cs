using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Bus
{
    public class BusRouteViewModel
    {   
        public long Id { get; set; }
        public long BusRouteId { get; set; }
        public string RegistrationPlate { get; set; }

        public int Capacity { get; set; }
    }
}
