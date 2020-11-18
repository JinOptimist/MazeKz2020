using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MazeKz;

namespace WebMaze.Models
{
    public class MazeKZViewModel
    {
        public List<MazeKZModel> Table { get; set; }
        public Maze Maze { get; set; }
    }
}
