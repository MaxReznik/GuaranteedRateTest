using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordProcessorLibrary.Domain;
using System.Linq;

namespace RecordProcessorLibrary.Tests
{
    [TestClass]
    public class GenderSorterTests
    {
        GenderSorter _sut = new GenderSorter();

        [TestMethod]
        public void SortTest()
        {
            var rec1 = new Record { Gender = Gender.Male };
            var rec2 = new Record { Gender = Gender.Female };
            var rec3 = new Record { Gender = Gender.Female };
            var rec4 = new Record { Gender = Gender.Male };

            var records = new Record[] { rec1, rec2, rec3, rec4 };

            var result = _sut.Sort(records).ToArray();

            Assert.AreEqual(rec1, result[0]);
            Assert.AreEqual(rec4, result[1]);
            Assert.AreEqual(rec2, result[2]);
            Assert.AreEqual(rec3, result[3]);
        }
    }
}