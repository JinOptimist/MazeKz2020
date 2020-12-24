using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model;

namespace WebMaze.DbStuff.Repository
{
    public class BusRouteRepository : BaseRepository<BusRoute>
    {
        public BusRouteRepository(WebMazeContext context) : base(context)
        {
        }

    }
}
