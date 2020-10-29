using MazeKz.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MazeKz
{
    public class MazeGenerator
    {
        private Random _random = new Random();
        private Maze _maze;

        public Maze GenerateSmart(int width = 10, int height = 5)
        {
            //Создали лабиринты полный стен
            _maze = GenerateMazeFullWall(width, height);

            //Координаты шахтёр
            var minerX = 0;
            var minerY = 0;

            GenerateWall(minerX, minerY);

            _maze.Hero = new Hero(0, 0, _maze);

            GenerateCoin();

            return _maze;
        }

        private void GenerateWall(int minerX, int minerY)
        {
            List<CellBase> cellsAllowToBreak = new List<CellBase>();
            do
            {
                //DraweMaze();

                //Разломать стeну, по координатам шахтёра
                BreakWall(minerX, minerY);
                var brokenWall = cellsAllowToBreak.SingleOrDefault(x => x.X == minerX && x.Y == minerY);
                if (brokenWall != null)
                {
                    cellsAllowToBreak.Remove(brokenWall);
                }

                //Выбрать ближайшие к шахтёры ячейки
                var nearCells = GetNearCells<Wall>(minerX, minerY);//CellType.Wall
                cellsAllowToBreak.AddRange(nearCells);
                cellsAllowToBreak = cellsAllowToBreak
                    .Where(wall =>
                        GetNearCells<Ground>(wall.X, wall.Y).Count() <= 1)//CellType.Ground
                    .Distinct()
                    .ToList();

                //Выбрать случайную ячейку, куда шагнёт шахтёр
                var randomCell = GetRandomCell(cellsAllowToBreak);

                minerX = randomCell?.X ?? 0;
                minerY = randomCell?.Y ?? 0;
            } while (cellsAllowToBreak.Any());
        }

        private void DraweMaze()
        {
            var drawer = new Drawer();
            drawer.DrawMaze(_maze);
            Console.WriteLine("----------------------------------");
            Thread.Sleep(200);
        }

        private void GenerateCoin()
        {
            var grounds = _maze.Cells.OfType<Ground>().ToList();

            for (int i = 0; i < 10; i++)
            {
                var randomGround = GetRandomCell(grounds);
                var coin = new Coin(randomGround.X, randomGround.Y, _maze);
                _maze.ReplaceCell(coin);
            }
        }

        private CellBase GetRandomCell(IEnumerable<CellBase> nearCells)
        {
            if (!nearCells.Any())
            {
                return null;
            }
            var list = nearCells.ToList();
            var randomIndex = _random.Next(0, list.Count());
            return list[randomIndex];
        }

        private IEnumerable<CellBase> GetNearCells<T>(int minerX, int minerY)
            where T : CellBase
        {
            var nearCells = new List<CellBase>()
            {
                _maze[minerX - 1, minerY],
                _maze[minerX + 1, minerY],
                _maze[minerX, minerY + 1],
                _maze[minerX, minerY - 1],
            };
            var answer = nearCells
                .Where(x => x != null)
                .OfType<T>();
            return answer;
        }

        private void BreakWall(int minerX, int minerY)
        {
            var ground = new Ground(minerX, minerY, _maze);
            _maze.ReplaceCell(ground);
        }

        private Maze GenerateMazeFullWall(int width, int height)
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
                    maze.Cells.Add(new Wall(x, y, maze));
                }
            }

            return maze;
        }
    }
}
