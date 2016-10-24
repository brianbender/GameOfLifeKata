using GameOfLife;
using NUnit.Framework;

namespace GameOfLifeTests
{
    [TestFixture]
    internal class Tests
    {
        private const string Empty2By2 = "..\n..";
        
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

        [Test]
        public void TwoByTwoWithTwoLives_Live()
        {
            const string inputBoard = "** *.";
            var game = new Board(2, 2, inputBoard);
            Assert.That(game.GetNextGeneration(), Is.EqualTo(inputBoard));
        }

        [TestCase(1, Cell.DeadCell)]
        [TestCase(2, Cell.DeadCell)]
        [TestCase(3, Cell.LiveCell)]
        [TestCase(4, Cell.DeadCell)]
        public void GetState(int neighborCount, char cellState)
        {
            var testObj = new Cell(1, 1, '.');
            Assert.That(testObj.GetState(neighborCount), Is.EqualTo(cellState));
        }
    }
}
