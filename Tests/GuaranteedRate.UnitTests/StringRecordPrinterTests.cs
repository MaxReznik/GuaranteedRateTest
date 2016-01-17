using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordProcessorLibrary.Domain;
using System;

namespace RecordProcessorLibrary.Tests
{
    [TestClass]
    public class StringRecordPrinterTests
    {
        StringRecordPrinter _sut = new StringRecordPrinter();
        
        [TestMethod]
        public void PrintRecordTest()
        {
            var record = new Record { FirstName = "First", LastName = "Last", DateOfBirth = DateTime.Now, FavoriteColor = "Red", Gender = Gender.Female };
            Assert.AreEqual(string.Format("Record: {0} {1} {2} {3:MM/dd/yyyy} {4}", record.FirstName, record.LastName, record.Gender, record.DateOfBirth, record.FavoriteColor), _sut.PrintRecord(record));
        }
    }
}