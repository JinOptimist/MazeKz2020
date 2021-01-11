using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Bus
{
    public class CreateRouteViewModel
    {   
        public long Id { get; set; }
        public string Route { get; set; }

    }
}
