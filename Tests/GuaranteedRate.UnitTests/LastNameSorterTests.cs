using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordProcessorLibrary;
using RecordProcessorLibrary.Domain;
using System.Linq;

namespace GuaranteedRate.UnitTests
{
    [TestClass]
    public class LastNameSorterTests
    {
        LastNameSorter _sut = new LastNameSorter();

        [TestMethod]
        public void SortTest()
        {
            var rec1 = new Record { LastName = "A" };
            var rec2 = new Record { LastName = "C" };
            var rec3 = new Record { LastName = "D" };
            var rec4 = new Record { LastName = "B" };

            var records = new Record[] { rec1, rec2, rec3, rec4 };

            var result = _sut.Sort(records).ToArray();

            Assert.AreEqual(rec3, result[0]);
            Assert.AreEqual(rec2, result[1]);
            Assert.AreEqual(rec4, result[2]);
            Assert.AreEqual(rec1, result[3]);

        }
    }
}
