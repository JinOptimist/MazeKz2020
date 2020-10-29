using System;
using System.Collections.Generic;
using System.Text;

namespace MazeKz.Cells
{
    public abstract class CellBase
    {
        public CellBase(int x, int y, Maze maze)
        {
            X = x;
            Y = y;
            Maze = maze;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Maze Maze { get; set; }

        public abstract bool TryStep();

        public override string ToString()
        {
            return $"[{X},{Y}]";
        }
    }
}
