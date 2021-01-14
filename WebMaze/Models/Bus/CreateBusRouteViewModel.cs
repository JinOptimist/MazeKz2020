using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.Models.CustomAttribute;

namespace WebMaze.Models.Bus
{
    public class CreateBusRouteViewModel
    {   
        public long Id { get; set; }

        [BusRouteLenght]
        public string Route { get; set; }

    }
}
