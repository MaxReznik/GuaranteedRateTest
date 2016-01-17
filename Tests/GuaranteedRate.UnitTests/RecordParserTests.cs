using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordProcessorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RecordProcessorLibrary.Domain;

namespace RecordProcessorLibrary.Tests
{
    [TestClass]
    public class RecordParserTests
    {
        RecordParser _sut;
        Mock<IEnumerable<IRecordSplitter>> _splitters;
        Mock<IRecordFromPiecesConverter> _converter;
        Mock<IRecordSplitter> _splitter;

        [TestInitialize]
        public void Setup()
        {
            _splitter = new Mock<IRecordSplitter>();
            _splitters = new Mock<IEnumerable<IRecordSplitter>>();
            _splitters.Setup(x => x.GetEnumerator()).Returns(new IRecordSplitter[] { _splitter.Object}.Select(s => s).GetEnumerator());

            _converter = new Mock<IRecordFromPiecesConverter>();

            _sut = new RecordParser(_splitters.Object, _converter.Object);
        }

        [TestMethod]
        public void ParseTest_Success()
        {
            var ob1Str = new string[]
            {
                "First1", "Last1", Gender.Female.ToString(), "Green", DateTime.Now.AddYears(-30).ToString("MM/dd/yyyy")
            };
            var ob2Str = new string[]
            {
                "First2", "Last2", Gender.Male.ToString(), "Red", DateTime.Now.AddYears(-40).ToString("MM/dd/yyyy")
            };

            var str1 = string.Join(" ", ob1Str);
            var str2 = string.Join(" ", ob2Str);

            var ob1 = new Record();
            var ob2 = new Record();
            
            _splitter.Setup(x => x.CanSplit(str1)).Returns(true);
            _splitter.Setup(x => x.Split(str1)).Returns(ob1Str);
            _splitter.Setup(x => x.Split(str2)).Returns(ob2Str);

            _converter.Setup(x => x.Convert(ob1Str)).Returns(ob1);
            _converter.Setup(x => x.Convert(ob2Str)).Returns(ob2);

            var result = _sut.Parse(new string[] { str1, str2 }).ToArray();

            Assert.AreEqual(ob1, result[0]);
            Assert.AreEqual(ob2, result[1]);
            _splitter.VerifyAll();
            _converter.VerifyAll();
        }
    }
}