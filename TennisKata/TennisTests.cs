using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisKata
{
    [TestClass]
    public class TennisTests
    {
        [TestMethod]
        public void Love_All()
        {
            Tennis tennis = new Tennis();
            var score = tennis.Score();
            Assert.AreEqual("Love All", score);
        }
    }
}