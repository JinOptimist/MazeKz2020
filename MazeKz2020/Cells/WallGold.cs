using System;
using System.Collections.Generic;
using System.Text;

namespace MazeKz.Cells
{
    public class WallGold : Wall
    {
        protected int _durability = 3;

        public WallGold(int x, int y, Maze maze) : base(x, y, maze)
        {
        }

        public override bool TryStep()
        {
            Maze.Hero.Money++;

            _durability--;

            if (_durability <= 0)
            {
                Maze.ReplaceToGround(this);
                return true;
            }

            return base.TryStep();
        }
    }
}
