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
            Console.Clear();

            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    var cell = maze.CellsWithHero.Single(cell => cell.X == x && cell.Y == y);
                    if (cell is Wall)
                    {
                        Console.Write("#");
                    }
                    else if (cell is Ground)
                    {
                        Console.Write(".");
                    }
                    else if (cell is Coin)
                    {
                        Console.Write("c");
                    }
                    else if (cell is Hero)
                    {
                        Console.Write("@");
                    }
                    else
                    {
                        throw new Exception($"Update way to display {cell.GetType()}");
                    }
                }

                Console.WriteLine();
            }
        }
        
    }
}
