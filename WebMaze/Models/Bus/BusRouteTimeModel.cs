using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Bus
{
    public class BusRouteTimeViewModel
    {   
        public long Id { get; set; }

        [Required]
        public string StartingPoint { get; set; }

        [Required]
        public string EndingPoint { get; set; }

        [Required]
        public int Minutes { get; set; }

    }
}
