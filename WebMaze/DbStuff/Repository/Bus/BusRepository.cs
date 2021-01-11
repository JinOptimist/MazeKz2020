using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model;

namespace WebMaze.DbStuff.Repository
{
    public class BusRepository : BaseRepository<Bus>
    {
        public BusRepository(WebMazeContext context) : base(context)
        {
        }

    }
}
