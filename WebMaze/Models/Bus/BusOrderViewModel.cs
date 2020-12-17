using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Bus
{
    public class BusOrderViewModel
    {
        public long Id { get; set; }
        public string Route { get; set; }
        public string RegistrationPlate { get; set; }


    }
}
