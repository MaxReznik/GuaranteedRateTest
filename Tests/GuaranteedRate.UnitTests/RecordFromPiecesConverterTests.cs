using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordProcessorLibrary.Domain;
using System;

namespace RecordProcessorLibrary.Tests
{
    [TestClass]
    public class RecordFromPiecesConverterTests
    {
        RecordFromPiecesConverter _sut = new RecordFromPiecesConverter();
        
        [TestMethod]
        public void ConvertTest_Success()
        {
            string firstName = "First";
            string lastName = "Last";
            Gender gender = Gender.Male;
            string color = "Red";
            DateTime dob = DateTime.Now;

            var result = _sut.Convert(new string[] { firstName, lastName, gender.ToString(), color, dob.ToString("MM/dd/yyyy") });

            Assert.AreEqual(firstName, result.FirstName);
            Assert.AreEqual(lastName, result.LastName);
            Assert.AreEqual(color, result.FavoriteColor);
            Assert.AreEqual(gender, result.Gender);
            Assert.AreEqual(dob.Day, result.DateOfBirth.Day);
            Assert.AreEqual(dob.Month, result.DateOfBirth.Month);
            Assert.AreEqual(dob.Year, result.DateOfBirth.Year);
        }
    }
}