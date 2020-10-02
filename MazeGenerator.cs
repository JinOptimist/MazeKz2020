using MazeKz.Cells;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeKz
{
    public class MazeGenerator
    {
        private Random _random = new Random();

        public Maze Generate(int width = 10, int height = 5)
        {
            var maze = new Maze
            {
                Width = width,
                Height = height
            };

            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Width; x++)
                {
                    var number = _random.Next(1, 4);

                    var cellType = (CellType)number;

                    var cell = new Cell(x, y, cellType);
                    maze.Cells.Add(cell);
                }
            }

            return maze;
        }
    }
}
