using System;
using System.Collections.Generic;
using System.Text;

namespace MazeKz
{
    public class ConsoleUiHelper
    {
        public void Play()
        {
            var mazeGenerator = new MazeGenerator();
            var maze = mazeGenerator.GenerateSmart(20, 10);

            var draw = new Drawer();
            draw.DrawMaze(maze);

            var continuePlay = true;
            while (continuePlay)
            {
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        maze.TryToStep(Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        maze.TryToStep(Direction.Right);
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        maze.TryToStep(Direction.Top);
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        maze.TryToStep(Direction.Bottom);
                        break;
                    case ConsoleKey.Escape:
                        continuePlay = false;
                        break;
                }

                draw.DrawMaze(maze);
            }

            Console.WriteLine("GoodBye");
        }
    }
}
