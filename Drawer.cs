using MazeKz.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeKz
{
    public class Drawer
    {
        public void DrawMaze(Maze maze)
        {
            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    var cell = maze.Cells.Single(cell => cell.X == x && cell.Y == y);
                    switch (cell.CellType)
                    {
                        case CellType.Wall:
                            Console.Write("#");
                            break;
                        case CellType.Ground:
                            Console.Write(".");
                            break;
                        case CellType.Coin:
                            Console.Write("c");
                            break;
                        default:
                            throw new Exception($"Update way to display {cell.CellType}");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
