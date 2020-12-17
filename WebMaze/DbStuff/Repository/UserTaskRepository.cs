using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;

namespace WebMaze.DbStuff.Repository
{
    public class UserTaskRepository : BaseRepository<UserTask>
    {
        public UserTaskRepository(WebMazeContext context) : base(context)
        {
        }
    }
}
