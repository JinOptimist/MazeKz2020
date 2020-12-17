using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Account
{
    public class AdressViewModel
    {
        public string City { get; set; }

        public string Street { get; set; }

        public int HouseNumber { get; set; }

        public long OwnerId { get; set; }
    }
}
