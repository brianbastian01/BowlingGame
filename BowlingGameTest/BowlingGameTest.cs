using NUnit.Framework;

namespace BowlingGameTest
{
	public class BowlingGameTest
	{
		private BowlingGame.BowlingGame _bowlingGame;

        [SetUp]
        public void SetUp()
        {
            _bowlingGame = new BowlingGame.BowlingGame();
        }

        private void rollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                _bowlingGame.Roll(pins);
            }
        }

        private void rollSpare()
        {
            _bowlingGame.Roll(6);
            _bowlingGame.Roll(4);
        }

        [Test]
        public void TestBowlingGameClass()
        {
            Assert.IsInstanceOf<BowlingGame.BowlingGame>(_bowlingGame);
        }

        [Test]
        public void TestGutterGame()
        {
            rollMany(20, 0);
            Assert.AreEqual(0, _bowlingGame.Score());
        }

        [Test]
        public void TestAllOnes()
        {
            rollMany(20, 1);
            Assert.AreEqual(20, _bowlingGame.Score());
        }

        [Test]
        public void TestOneSpare()
        {
            rollSpare();
            _bowlingGame.Roll(4);
            rollMany(17, 0);
            Assert.AreEqual(18, _bowlingGame.Score());
        }

        [Test]
        public void TestOneStrike()
        {
            _bowlingGame.Roll(10);
            _bowlingGame.Roll(4);
            _bowlingGame.Roll(5);
            rollMany(17, 0);
            Assert.AreEqual(28, _bowlingGame.Score());
        }

        [Test]
        public void TestFullHouseGame()
        {
            rollMany(12, 10);
            Assert.AreEqual(300, _bowlingGame.Score());
        }

        [Test]
        public void TestRandomGameNoExtraRoll()
        {
            _bowlingGame.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 4, 2, 5, 3, 8, 2, 7, 2, 10, 9, 3 });
            Assert.AreEqual(124, _bowlingGame.Score());
        }

        [Test]
        public void TestRandomGameWithSpareThenStrikeAtEnd()
        {
            _bowlingGame.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
            Assert.AreEqual(143, _bowlingGame.Score());
        }
    }
}