using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordProcessorLibrary;

namespace GuaranteedRate.UnitTests
{
    [TestClass]
    public class PipeSplitterTests
    {
        PipeSplitter _sut = new PipeSplitter();

        [TestMethod]
        public void CanSplitTest_Success()
        {
            Assert.IsTrue(_sut.CanSplit("|"));
        }

        [TestMethod]
        public void SplitTest_Success()
        {
            var result = _sut.Split("aaa|bbb|ccc|ddd|eee");

            Assert.AreEqual(5, result.Length);
            Assert.AreEqual("aaa", result[0]);
            Assert.AreEqual("bbb", result[1]);
            Assert.AreEqual("ccc", result[2]);
            Assert.AreEqual("ddd", result[3]);
            Assert.AreEqual("eee", result[4]);
        }
    }
}
