using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecordProcessorLibrary.Tests
{
    [TestClass]
    public class SpaceSplitterTests
    {
        SpaceSplitter _sut = new SpaceSplitter();
                
        [TestMethod]
        public void CanSplitTest_Success()
        {
            Assert.IsTrue(_sut.CanSplit(" "));
        }

        [TestMethod]
        public void SplitTest_Success()
        {
            var result = _sut.Split("aaa bbb ccc ddd eee");

            Assert.AreEqual(5, result.Length);
            Assert.AreEqual("aaa", result[0]);
            Assert.AreEqual("bbb", result[1]);
            Assert.AreEqual("ccc", result[2]);
            Assert.AreEqual("ddd", result[3]);
            Assert.AreEqual("eee", result[4]);
        }
    }
}