using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model;

namespace WebMaze.DbStuff.Repository
{
    public class BusStopRepository : BaseRepository<BusStop>
    {
        public BusStopRepository(WebMazeContext context) : base(context)
        {
        }

    }
}
