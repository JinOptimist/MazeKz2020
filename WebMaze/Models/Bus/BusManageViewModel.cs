using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Bus
{
    public class BusManageViewModel
    {
        public long Id { get; set; }
        public long BusRouteId { get; set; }
        public string RegistrationPlate { get; set; }
        public long WorkerId { get; set; }
        public int Capacity { get; set; }
        public List<BusViewModel> buses { get; set; }

        public BusManageViewModel() : base()
        {
            buses = new List<BusViewModel>();
        }
    }
}
