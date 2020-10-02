using System;
using System.Collections.Generic;
using System.Text;

namespace MazeKz.Cells
{
    public class Cell
    {
        public Cell(int x, int y, CellType cellType)
        {
            X = x;
            Y = y;
            CellType = cellType;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public CellType CellType { get; set; }
    }
}
