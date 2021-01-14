using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Bus
{
    public class BusRouteTimeManagmentViewModel
    {
        public BusRouteTimeViewModel BusRouteTime { get; set; }

        public List<BusRouteTimeViewModel> BusRouteTimeList { get; set; }

        public BusRouteTimeManagmentViewModel() : base()
        {
            BusRouteTimeList = new List<BusRouteTimeViewModel>();
        }

    }
}
