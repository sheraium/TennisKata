using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace AsyncUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var sut = new SUT();
            await Task.Delay(1000);
            var actual = await sut.DoAsync();
            Assert.AreEqual("Wait", actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var sut = new SUT();
            Task.Delay(1000).Wait();
            var actual = sut.DoAsync().Result;
            Assert.AreEqual("Wait", actual);
        }
    }

    public class SUT
    {
        public async Task<string> DoAsync()
        {
            return await Task.Run(() =>
             {
                 return "Wait";
             });
        }
    }
}