using DanskeTask.Core.Interfaces.BusinessLogic;
using DanskeTask.Infrastructure.BusinessLogic;
using System;
using System.Collections.Generic;
using Xunit;

namespace DanskeTask.Tests
{
    public class ConversionLogicTests
    {
        private readonly IConversionLogic _conversionLogic;

        public ConversionLogicTests()
        {
            _conversionLogic = new ConversionLogic();
        }

        [Fact]
        public void ConvertToListOfNumbers_NullStringOfNumbers_ShouldThrowException()
        {
            string stringOfNumbers = null;
            char delimiter = ' ';

            Assert.Throws<NullReferenceException>(() => _conversionLogic.ConvertToListOfNumbers(stringOfNumbers, delimiter));
        }

        [Fact]
        public void ConvertToListOfNumbers_EmptyStringOfNumbers_ShouldThrowException()
        {
            string stringOfNumbers = "";
            char delimiter = ' ';

            Assert.Throws<FormatException>(() => _conversionLogic.ConvertToListOfNumbers(stringOfNumbers, delimiter));
        }

        [Fact]
        public void ConvertToListOfNumbers_WrongDelimiter_ShouldThrowException()
        {
            string stringOfNumbers = "1 5 6 16";
            char delimiter = ',';

            Assert.Throws<FormatException>(() => _conversionLogic.ConvertToListOfNumbers(stringOfNumbers, delimiter));
        }

        [Fact]
        public void ConvertToListOfNumbers_CorruptStringOfNumbers_ShouldThrowException()
        {
            string stringOfNumbers = "1 5, -6 16";
            char delimiter = ',';

            Assert.Throws<FormatException>(() => _conversionLogic.ConvertToListOfNumbers(stringOfNumbers, delimiter));
        }

        [Fact]
        public void ConvertToListOfNumbers_ShouldReturnList()
        {
            string stringOfNumbers = "1 5 -6 16";
            char delimiter = ' ';

            List<long> expectedReult = new List<long>() { 1, 5, -6, 16 };

            var actualResult = _conversionLogic.ConvertToListOfNumbers(stringOfNumbers, delimiter);

            Assert.Equal(expectedReult, actualResult);
        }

        [Fact]
        public void ConvertToStringOfNumbers_EmptyList_ShouldReturnEmptyString()
        {
            List<long> numbersList = new List<long>();
            char delimiter = ' ';

            string expectedReult = "";

            var actualResult = _conversionLogic.ConvertToStringOfNumbers(numbersList, delimiter);

            Assert.Equal(expectedReult, actualResult);
        }

        [Fact]
        public void ConvertToStringOfNumbers_NullList_ShouldThrowException()
        {
            List<long> numbersList = null;
            char delimiter = ' ';

            Assert.Throws<ArgumentNullException>(() => _conversionLogic.ConvertToStringOfNumbers(numbersList, delimiter));
        }

        [Fact]
        public void ConvertToStringOfNumbers_ShouldReturnStringOfNumbers()
        {
            List<long> numbersList = new List<long>() { 1, -5, 16 };
            char delimiter = ' ';

            string expectedReult = "1 -5 16";

            var actualResult = _conversionLogic.ConvertToStringOfNumbers(numbersList, delimiter);

            Assert.Equal(expectedReult, actualResult);
        }
    }
}
