using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model
{
    public class CitizenUser : BaseModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string AvatarUrl { get; set; }
    }
}
