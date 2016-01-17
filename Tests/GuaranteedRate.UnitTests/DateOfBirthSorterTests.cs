using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordProcessorLibrary;
using RecordProcessorLibrary.Domain;
using System;
using System.Linq;

namespace GuaranteedRate.UnitTests
{
    [TestClass]
    public class DateOfBirthSorterTests
    {
        DateOfBirthSorter _sut = new DateOfBirthSorter();

        [TestMethod]
        public void SortTest()
        {
            var rec1 = new Record { DateOfBirth = DateTime.Now };
            var rec2 = new Record { DateOfBirth = DateTime.Now.AddYears(-5) };
            var rec3 = new Record { DateOfBirth = DateTime.Now.AddYears(5) };
            var rec4 = new Record { DateOfBirth = DateTime.Now.AddYears(-10) };

            var records = new Record[] { rec1, rec2, rec3, rec4 };

            var result = _sut.Sort(records).ToArray();

            Assert.AreEqual(rec4, result[0]);
            Assert.AreEqual(rec2, result[1]);
            Assert.AreEqual(rec1, result[2]);
            Assert.AreEqual(rec3, result[3]);

        }
    }
}
