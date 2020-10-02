using MazeKz.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeKz
{
    public class Maze
    {
        public List<Cell> Cells { get; set; }

        //public int WidthGet => Cells.Max(cell => cell.X);
        public int Width { get; set; }
        public int Height { get; set; }

        public Maze()
        {
            Cells = new List<Cell>();
        }
    }
}
