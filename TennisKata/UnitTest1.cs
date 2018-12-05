using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisKata
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void METHOD()
        {
            TennisGame tennisGame = new TennisGame();
            var score = tennisGame.Score();
            Assert.AreEqual("Love All", score);
        }
    }
}