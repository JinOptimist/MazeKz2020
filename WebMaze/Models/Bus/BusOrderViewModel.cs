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
        public DateTime OrderDate { get; set; }
        public DateTime TargetedDate { get; set; }
        public string OrderDescription { get; set; }

    }
}
