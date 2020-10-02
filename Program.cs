using System;

namespace MazeKz
{
    class Program
    {
        static void Main(string[] args)
        {
            var mazeGenerator = new MazeGenerator();
            var maze = mazeGenerator.Generate();
            var draw = new Drawer();
            draw.DrawMaze(maze);
        }
    }
}
