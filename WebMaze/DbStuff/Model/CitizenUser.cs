using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model
{
    public class CitizenUser
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string AvatarUrl { get; set; }
    }
}
