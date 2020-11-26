using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model
{
    public class Adress : BaseModel
    {
        public string City { get; set; }

        public string Street { get; set; }

        public int HouseNumber { get; set; }
    }
}
