using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisKata
{
    [TestClass]
    public class UnitTest1
    {
            TennisGame tennisGame = new TennisGame();
        [TestMethod]
        public void METHOD()
        {
            ScoreShouldBe("Love All");
        }

        private void ScoreShouldBe(string expected)
        {
            var score = tennisGame.Score();
            Assert.AreEqual(expected, score);
        }
    }
}