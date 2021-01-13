using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Bus
{
    public class BusManageViewModel
    {
        public BusViewModel Bus { get; set; }
        public List<BusViewModel> Buses { get; set; }

        public BusManageViewModel() : base()
        {
            Buses = new List<BusViewModel>();
        }
    }
}
