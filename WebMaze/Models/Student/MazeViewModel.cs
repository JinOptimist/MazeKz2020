using MazeKz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models
{
    public class MazeViewModel
    {
        public MazeViewModel(Maze maze)
        {
            Width = maze.Width;
            Height = maze.Height;
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Cells.Add(new MazeCellModel(x, y, cellType(maze[x, y])));
                }
            }
        }

        public ICollection<MazeCellModel> Cells { get; } = new List<MazeCellModel>();
        public int Width { get; set; }
        public int Height { get; set; }

        public string this[int x, int y] => Cells.SingleOrDefault(c => c.X == x && c.Y == y).CellType;

        private string cellType(MazeKz.Cells.CellBase cell)
        {
            switch (cell)
            {
                case MazeKz.Cells.Coin c:
                    return "coin";
                case MazeKz.Cells.WallGold c:
                    return "wall gold";
                case MazeKz.Cells.Wall c:
                    return "wall";
                case MazeKz.Cells.Ground c:
                    return "ground";
                case MazeKz.Cells.Hero c:
                    return "hero";
                default:
                    return "";
            }
        }
    }

    public class MazeCellModel
    {
        public MazeCellModel(int x, int y, string type)
        {
            X = x;
            Y = y;
            CellType = type;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string CellType { get; set; }
    }
}
