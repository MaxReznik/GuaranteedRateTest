using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RecordProcessorLibrary;
using RecordProcessorLibrary.Domain;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApi.Controllers;

namespace GuaranteedRate.UnitTests.Web
{
    [TestClass]
    public class GuaranteerRateControllerTest
    {
        Mock<IRecordParser> _recordParser;
        Mock<IGenderSorter> _genderSorter;
        Mock<IDateOfBirthSorter> _dobSorter;
        Mock<ILastNameSorter> _lastNameSorter;
        Mock<ControllerContext> _context;
        GuaranteedRateController _sut;

        [TestInitialize]
        public void Setup()
        {
            _context = new Mock<ControllerContext>();
            _recordParser = new Mock<IRecordParser>();
            _genderSorter = new Mock<IGenderSorter>();
            _dobSorter = new Mock<IDateOfBirthSorter>();
            _lastNameSorter = new Mock<ILastNameSorter>();

            _sut = new GuaranteedRateController(_recordParser.Object, _genderSorter.Object, _dobSorter.Object, _lastNameSorter.Object);
            _sut.ControllerContext = _context.Object;
        }



        [TestMethod]
        public void TestPostCreatesNewListOfRecordsIfDoesnotExist()
        {
            string str1 = "Max|Reznik|Male|Red|01/01/1983";
            string str2 = "Alena|Reznik|Female|Blue|02/01/1985";

            List<Record> records = new List<Record>();
            _context.Setup(x => x.HttpContext.Session["Records"]).Returns(records);
            _recordParser.Setup(x => x.Parse(new string[] { str1, str2 })).Returns(new Record[] { new Record(), new Record() });
            _sut.Records(string.Join("\n", str1, str2));
            
            Assert.AreEqual(2, records.Count);
        }

        [TestMethod]
        public void TestCallingPostMultipleTimesRetainsExistingRecords()
        {
            string str1 = "Max|Reznik|Male|Red|01/01/1983";
            string str2 = "Alena|Reznik|Female|Blue|02/01/1985";

            List<Record> records = new List<Record>();
            _context.Setup(x => x.HttpContext.Session["Records"]).Returns(records);
            _recordParser.Setup(x => x.Parse(new string[] { str1, str2 })).Returns(new Record[] { new Record(), new Record() });
            _sut.Records(string.Join("\n", str1, str2));

            Assert.AreEqual(2, records.Count);

            _sut.Records(string.Join("\n", str1, str2));

            Assert.AreEqual(4, records.Count);
            _recordParser.Verify(x => x.Parse(new string[] { str1, str2 }), Times.Exactly(2));
        }

        [TestMethod]
        public void TestSortByGender()
        {
            List<Record> records = new List<Record> { new Record(), new Record()};
            _context.Setup(x => x.HttpContext.Session["Records"]).Returns(records);
            _genderSorter.Setup(x => x.Sort(records)).Returns(records);
            var result = _sut.Gender() as JsonResult;

            var rData = result.Data as Record[];

            Assert.AreEqual(records[0], rData[0]);
            Assert.AreEqual(records[1], rData[1]);

            _genderSorter.VerifyAll();

        }

        [TestMethod]
        public void TestSortByDob()
        {
            List<Record> records = new List<Record> { new Record(), new Record() };
            _context.Setup(x => x.HttpContext.Session["Records"]).Returns(records);
            _dobSorter.Setup(x => x.Sort(records)).Returns(records);
            var result = _sut.BirthDate() as JsonResult;

            var rData = result.Data as Record[];

            Assert.AreEqual(records[0], rData[0]);
            Assert.AreEqual(records[1], rData[1]);

            _dobSorter.VerifyAll();

        }

        [TestMethod]
        public void TestSortByLastName()
        {
            List<Record> records = new List<Record> { new Record(), new Record() };
            _context.Setup(x => x.HttpContext.Session["Records"]).Returns(records);
            _lastNameSorter.Setup(x => x.Sort(records)).Returns(records);
            var result = _sut.Name() as JsonResult;

            var rData = result.Data as Record[];

            Assert.AreEqual(records[0], rData[0]);
            Assert.AreEqual(records[1], rData[1]);

            _lastNameSorter.VerifyAll();

        }
    }
}
