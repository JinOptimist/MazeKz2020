using MazeKz.Cells;
using Moq;
using NUnit.Framework;
using System;

namespace MazeKz.Tests.Cells
{
    public class WallGoldTests
    {
        [Test]
        [TestCase(1, 1, false, false)]
        [TestCase(2, 2, false, false)]
        [TestCase(3, 3, true, true)]
        public void TryStep_WallGold(int countOfAttempt, int coinCount, 
            bool wallWasBroken, bool canStep)
        {
            //Подготовка данных
            var mazeMock = new Mock<Maze>();
            var maze = mazeMock.Object;

            var heroMock = new Mock<Hero>();
            heroMock.SetupAllProperties();

            var hero = heroMock.Object;
            hero.Money = 0;

            mazeMock.Setup(x => x.Hero).Returns(hero);

            var wallGold = new WallGold(1, 1, maze);

            //Действие
            var answer = false;
            for (int i = 0; i < countOfAttempt; i++)
            {
                answer = wallGold.TryStep();
            }

            //Проверки
            Assert.AreEqual(coinCount, hero.Money);
            if (wallWasBroken)
            {
                mazeMock.Verify(x => x.ReplaceToGround(wallGold), Times.Once);
            }

            Assert.AreEqual(canStep, answer);
        }
    }
}
