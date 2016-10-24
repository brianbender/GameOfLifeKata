using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeTests
{
    [TestFixture]
    internal class Tests
    {
        private const string Empty2By2 = "..\n..";

        [Test]
        public void SimpleTestDead()
        {
            var gameOfLife = new Board(1, 1, ".");
            Assert.That(gameOfLife.GetNextGeneration(), Is.EqualTo("."));
        }

        [Test]
        public void SimpleTestLive()
        {
            var gameOfLife = new Board(1, 1, "*");
            Assert.That(gameOfLife.GetNextGeneration(), Is.EqualTo("."));
        }

        [Test]
        public void TwobyTwoPrintsAtAll()
        {
            var game = new Board(2, 2, ".. ..");
            Assert.That(game.GetNextGeneration(), Is.EqualTo(Empty2By2));
        }

        [Test]
        public void TwoByTwoWithOneLife_Dies()
        {
            var game = new Board(2, 2, "*. ..");
            Assert.That(game.GetNextGeneration(), Is.EqualTo(Empty2By2));
        }
    }
}
