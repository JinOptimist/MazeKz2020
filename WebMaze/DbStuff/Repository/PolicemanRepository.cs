using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Police;

namespace WebMaze.DbStuff.Repository
{
    public class PolicemanRepository : BaseRepository<Policeman>
    {
        public PolicemanRepository(WebMazeContext context) : base(context) { }
    }
}
