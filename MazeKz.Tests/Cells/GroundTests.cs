using MazeKz.Cells;
using NUnit.Framework;
using System;

namespace MazeKz.Tests.Cells
{
    public class GroundTests
    {
        [Test]
        public void TryStep_Ground()
        {
            //Подготовка данных
            var ground = new Ground(1, 1, null);

            //Действие
            var answer = ground.TryStep();

            //Проверки
            Assert.AreEqual(true, answer);
        }
    }
}
