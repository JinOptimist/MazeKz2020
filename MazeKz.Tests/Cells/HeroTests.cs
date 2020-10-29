using MazeKz.Cells;
using NUnit.Framework;
using System;

namespace MazeKz.Tests.Cells
{
    public class HeroTests
    {
        [Test]
        public void TryStep_Hero()
        {
            //Подготовка данных
            var hero = new Hero(1, 1, null);

            //Действие
            //Проверка
            Assert.Throws<NotImplementedException>(() => hero.TryStep());
        }
    }
}
