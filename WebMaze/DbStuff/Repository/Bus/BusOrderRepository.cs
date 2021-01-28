using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model;

namespace WebMaze.DbStuff.Repository
{
    public class BusOrderRepository : BaseRepository<Bus>
    {
        public BusOrderRepository(WebMazeContext context) : base(context)
        {
        }

    }
}
