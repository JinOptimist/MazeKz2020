using System;
using System.Collections.Generic;
using System.Text;

namespace MazeKz.Cells
{
    public class Coin : CellBase
    {
        public Coin(int x, int y, Maze maze) : base(x, y, maze)
        {
        }

        public override bool TryStep()
        {
            Maze.Hero.Money++;

            Maze.ReplaceToGround(this);

            return true;
        }
    }
}
