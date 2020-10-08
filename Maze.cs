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

        public Cell this[int x, int y]
        {
            get
            {
                return Cells.SingleOrDefault(c => c.X == x && c.Y == y);
            }

            set
            {
                var oldCell = Cells.SingleOrDefault(c => c.X == x && c.Y == y);
                Cells.Remove(oldCell);

                Cells.Add(value);
            }
        }

        public Maze()
        {
            Cells = new List<Cell>();
        }
    }
}
