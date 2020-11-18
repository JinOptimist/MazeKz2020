using MazeKz;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeKz
{
    public class MazeForWeb
    {
        public  static Maze Mazes()
        {

            MazeGenerator mazeGenerator = new MazeGenerator();
            return SingeltonMaze.getInstance(mazeGenerator.GenerateSmart(20, 10)).Name;
        }
    }
    public class SingeltonMaze
    {
       
            private static SingeltonMaze instance;

            public Maze Name { get; private set; }
            private static object syncRoot = new Object();

            protected SingeltonMaze(Maze name)
            {
                this.Name = name;
            }

            public static SingeltonMaze getInstance(Maze name)
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SingeltonMaze(name);
                    }
                }
                return instance;
            }
       
    }
}
