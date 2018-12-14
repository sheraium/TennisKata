using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisKata
{
    [TestClass]
    public class TennisTests
    {
        private Tennis tennis = new Tennis();

        [TestMethod]
        public void Love_All()
        {
            ScoreShouldBe("Love All");
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            tennis.FirstPlayerScoreTimes();
            ScoreShouldBe("Fifteen Love");
        }

        [TestMethod]
        public void Thirty_Love()
        {
            tennis.FirstPlayerScoreTimes();
            tennis.FirstPlayerScoreTimes();
            ScoreShouldBe("Thirty Love");
        }

        private void ScoreShouldBe(string expected)
        {
            var score = tennis.Score();
            Assert.AreEqual(expected, score);
        }
    }
}