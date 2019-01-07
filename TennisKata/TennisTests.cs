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
            tennis.FirstPlayerScore();
            ScoreShouldBe("Fifteen Love");
        }

        [TestMethod]
        public void Thirty_Love()
        {
            GivenFirstPlayerScoreTimes(2);
            ScoreShouldBe("Thirty Love");
        }

        [TestMethod]
        public void Forty_Love()
        {
            GivenFirstPlayerScoreTimes(3);
            ScoreShouldBe("Forty Love");
        }

        [TestMethod]
        public void Love_Fifteen()
        {
            tennis.SecondPlayerScore();
            ScoreShouldBe("Love Fifteen");
        }

        [TestMethod]
        public void Love_Thirty()
        {
            GivenSecondPlayerScoreTimes(2);
            ScoreShouldBe("Love Thirty");
        }

        [TestMethod]
        public void Fifteen_All()
        {
            GivenFirstPlayerScoreTimes(1);
            GivenSecondPlayerScoreTimes(2);
            ScoreShouldBe("Fifteen All");
        }

        private void GivenSecondPlayerScoreTimes(int times)
        {
            for (var i = 0; i < times; i++)
            {
                tennis.SecondPlayerScore();
            }
        }

        private void GivenFirstPlayerScoreTimes(int times)
        {
            for (var i = 0; i < times; i++)
            {
                tennis.FirstPlayerScore();
            }
        }

        private void ScoreShouldBe(string expected)
        {
            var score = tennis.Score();
            Assert.AreEqual(expected, score);
        }
    }
}