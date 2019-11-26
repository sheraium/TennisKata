using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisKata
{
    [TestClass]
    public class TennisTests
    {
        private Tennis _tennis = new Tennis("Joey", "Tom");

        [TestMethod]
        public void Love_All()
        {
            ScoreShouldBe("Love All");
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            _tennis.FirstPlayerScore();
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
            _tennis.SecondPlayerScore();
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
            GivenSecondPlayerScoreTimes(1);
            ScoreShouldBe("Fifteen All");
        }

        [TestMethod]
        public void Thirty_All()
        {
            GivenFirstPlayerScoreTimes(2);
            GivenSecondPlayerScoreTimes(2);
            ScoreShouldBe("Thirty All");
        }

        [TestMethod]
        public void Deuce()
        {
            GivenFirstPlayerScoreTimes(3);
            GivenSecondPlayerScoreTimes(3);
            ScoreShouldBe("Deuce");
        }

        [TestMethod]
        public void FirstPlayer_Adv()
        {
            GivenFirstPlayerScoreTimes(4);
            GivenSecondPlayerScoreTimes(3);
            ScoreShouldBe("Joey Adv");
        }

        [TestMethod]
        public void SecondPlayer_Adv()
        {
            GivenFirstPlayerScoreTimes(3);
            GivenSecondPlayerScoreTimes(4);
            ScoreShouldBe("Tom Adv");
        }

        [TestMethod]
        public void SecondPlayer_Win()
        {
            GivenFirstPlayerScoreTimes(3);
            GivenSecondPlayerScoreTimes(5);
            ScoreShouldBe("Tom Win");
        }

        private void GivenSecondPlayerScoreTimes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _tennis.SecondPlayerScore();
            }
        }

        private void GivenFirstPlayerScoreTimes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _tennis.FirstPlayerScore();
            }
        }

        private void ScoreShouldBe(string expected)
        {
            Assert.AreEqual(expected, _tennis.Score());
        }
    }
}