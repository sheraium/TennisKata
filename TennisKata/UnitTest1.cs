using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisKata
{
    [TestClass]
    public class UnitTest1
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
            tennis.FirstPlayerScore();
            ScoreShouldBe("Fifteen Love");
        }

        private void ScoreShouldBe(string expected)
        {
            var score = tennis.Score();
            Assert.AreEqual(expected, score);
        }
    }
}