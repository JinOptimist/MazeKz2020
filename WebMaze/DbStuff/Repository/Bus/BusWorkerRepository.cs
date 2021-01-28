using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model;

namespace WebMaze.DbStuff.Repository
{
    public class BusWorkerRepository : BaseRepository<Bus>
    {
        public BusWorkerRepository(WebMazeContext context) : base(context)
        {
        }

    }
}
