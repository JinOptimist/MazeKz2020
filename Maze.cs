using MazeKz.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeKz
{
    public class Maze
    {
        public List<CellBase> Cells { get; set; }

        public List<CellBase> CellsWithHero
        {
            get
            {
                var copyCells = Cells.ToList();
                ReplaceCell(copyCells, Hero);
                return copyCells;
            }
        }

        public Hero Hero { get; set; }

        //public int WidthGet => Cells.Max(cell => cell.X);
        public int Width { get; set; }
        public int Height { get; set; }

        public CellBase this[int x, int y]
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
            Cells = new List<CellBase>();
        }

        public void TryToStep(Direction direction)
        {
            var heroX = Hero.X;
            var heroY = Hero.Y;

            switch (direction)
            {
                case Direction.Left:
                    heroX--;
                    break;
                case Direction.Top:
                    heroY--;
                    break;
                case Direction.Right:
                    heroX++;
                    break;
                case Direction.Bottom:
                    heroY++;
                    break;
            }

            var destanation = this[heroX, heroY];
            if (destanation == null)
            {
                return;
            }

            if (destanation.TryStep())
            {
                Hero.X = heroX;
                Hero.Y = heroY;
            }
        }

        public void ReplaceCell(CellBase newCell)
        {
            ReplaceCell(Cells, newCell);
        }

        public void ReplaceCell(List<CellBase> cells, CellBase newCell)
        {
            var cellForRemove = cells
                .SingleOrDefault(currentCell => currentCell.X == newCell.X && currentCell.Y == newCell.Y);
            cells.Remove(cellForRemove);
            cells.Add(newCell);
        }
    }

    public enum Direction
    {
        Left = 1,
        Top = 2,
        Right = 3,
        Bottom = 4,
    }
}
