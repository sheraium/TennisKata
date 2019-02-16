using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisKata
{
    [TestClass]
    public class TennisTests
    {
        [TestMethod]
        public void Love_All()
        {
            var tennis = new Tennis();
            var score = tennis.Score();
            Assert.AreEqual("Love All", score);
        }
    }
}