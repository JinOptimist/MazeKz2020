using MazeKz.Cells;
using NUnit.Framework;
using System;

namespace MazeKz.Tests.Cells
{
    public class WallTests
    {
        [Test]
        public void TryStep_Wall()
        {
            //Подготовка данных
            var wall = new Wall(1, 1, null);

            //Действие
            var answer = wall.TryStep();

            //Проверки
            Assert.AreEqual(false, answer);
        }
    }
}
