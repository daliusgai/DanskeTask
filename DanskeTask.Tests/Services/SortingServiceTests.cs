using DanskeTask.Core.DTO;
using DanskeTask.Core.Enumerators;
using DanskeTask.Core.Interfaces.BusinessLogic;
using DanskeTask.Core.Interfaces.Repositories;
using DanskeTask.Core.Interfaces.Services;
using DanskeTask.Infrastructure.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DanskeTask.Tests
{
    public class SortingServiceTests
    {
        [Fact]
        public void Sort_NullStringOfNumbers_ShouldReturnNull()
        {
            var sortingService = SetupSortingServiceForSort_ShouldReturnNull();
            string stringOfNumbers = null;

            SortResponseDTO expectedReult = null;

            var actualResult = sortingService.Sort(stringOfNumbers);

            Assert.Equal(expectedReult, actualResult);
        }

        [Fact]
        public void Sort_StringOfNumbersWithCorruptDelimiter_ShouldReturnNull()
        {
            var sortingService = SetupSortingServiceForSort_ShouldReturnNull();
            string stringOfNumbers = "5 464 65 87,45";

            SortResponseDTO expectedReult = null;

            var actualResult = sortingService.Sort(stringOfNumbers);

            Assert.Equal(expectedReult, actualResult);
        }

        [Fact]
        public void Sort_CorruptStringOfNumbers_ShouldReturnNull()
        {
            var sortingService = SetupSortingServiceForSort_ShouldReturnNull();
            string stringOfNumbers = "5 464 65 aswf87 45";

            SortResponseDTO expectedReult = null;

            var actualResult = sortingService.Sort(stringOfNumbers);

            Assert.Equal(expectedReult, actualResult);
        }

        [Fact]
        public void Sort_OutOfBoundsStringOfNumbers_ShouldReturnNull()
        {
            var sortingService = SetupSortingServiceForSort_ShouldReturnNull();
            string stringOfNumbers = "5 464 65 85 545468486846153111525416841681616816816887496126181919861919819189611686161623166416845";

            SortResponseDTO expectedReult = null;

            var actualResult = sortingService.Sort(stringOfNumbers);

            Assert.Equal(expectedReult, actualResult);
        }

        [Fact]
        public void Sort_ShouldReturnSortResponseDTO()
        {
            string stringOfNumbers = "5 464 65 85 5454";
            string sortedStringOfNumbers = "5 65 85 464 5454";
            List<long> numberList = new List<long>() { 5, 464, 65, 85, 5454 };
            List<long> sortedNumberList = new List<long>() { 5, 65, 85, 464, 5454 };

            var sortingService = SetupSortingServiceForSort(sortedStringOfNumbers, numberList, sortedNumberList);
            
            SortResponseDTO expectedReult = new SortResponseDTO
            {
                SortedNumbers = "5 65 85 464 5454",
                AlgortihmPerformance = new List<SortAlgorithmResponseDTO>()
                {
                    new SortAlgorithmResponseDTO() { AlgorithmTitle = Enum.GetName(typeof(ESortingAlgorithms), ESortingAlgorithms.BubbleSort), DurationInMiliseconds = It.IsAny<double>() },
                    new SortAlgorithmResponseDTO() { AlgorithmTitle = Enum.GetName(typeof(ESortingAlgorithms), ESortingAlgorithms.InsertionSort), DurationInMiliseconds = It.IsAny<double>() },
                    new SortAlgorithmResponseDTO() { AlgorithmTitle = Enum.GetName(typeof(ESortingAlgorithms), ESortingAlgorithms.QuickSort), DurationInMiliseconds = It.IsAny<double>() }
                }
            };

            var actualResult = sortingService.Sort(stringOfNumbers);

            Assert.Equal(expectedReult.SortedNumbers, actualResult.SortedNumbers);
            Assert.Equal(expectedReult.AlgortihmPerformance.Select(x => x.AlgorithmTitle).ToList(), actualResult.AlgortihmPerformance.Select(x => x.AlgorithmTitle).ToList());
            Assert.True(actualResult.AlgortihmPerformance.All(x => x.DurationInMiliseconds != default));
        }

        private ISortingService SetupSortingServiceForSort_ShouldReturnNull()
        {
            var mockSortingRepository = new Mock<ISortingRepository>();
            var mockSortingLogic = new Mock<ISortingLogic>();
            var mockConversionLogic = new Mock<IConversionLogic>();

            mockSortingRepository.Setup(x => x.SaveSortedNumbers(It.IsAny<string>()));

            mockSortingLogic.Setup(x => x.SortUsingBubbleSort(It.IsAny<List<long>>()));
            mockSortingLogic.Setup(x => x.SortUsingInsertionSort(It.IsAny<List<long>>()));
            mockSortingLogic.Setup(x => x.SortUsingQuickSort(It.IsAny<List<long>>()));

            mockConversionLogic.Setup(x => x.ConvertToListOfNumbers(It.IsAny<string>(), It.IsAny<char>()));
            mockConversionLogic.Setup(x => x.ConvertToStringOfNumbers(It.IsAny<List<long>>(), It.IsAny<char>()));

            return new SortingService(mockSortingRepository.Object, mockSortingLogic.Object, mockConversionLogic.Object);
        }

        private ISortingService SetupSortingServiceForSort(string sortedStringOfNumbers, List<long> numberList, List<long> sortedNumberList)
        {
            var mockSortingRepository = new Mock<ISortingRepository>();
            var mockSortingLogic = new Mock<ISortingLogic>();
            var mockConversionLogic = new Mock<IConversionLogic>();

            mockSortingRepository.Setup(x => x.SaveSortedNumbers(It.IsAny<string>()));

            mockSortingLogic.Setup(x => x.SortUsingBubbleSort(It.IsAny<List<long>>())).Callback<List<long>>(x => x = sortedNumberList);
            mockSortingLogic.Setup(x => x.SortUsingInsertionSort(It.IsAny<List<long>>())).Callback<List<long>>(x => x = sortedNumberList);
            mockSortingLogic.Setup(x => x.SortUsingQuickSort(It.IsAny<List<long>>())).Callback<List<long>>(x => x = sortedNumberList);

            mockConversionLogic.Setup(x => x.ConvertToListOfNumbers(It.IsAny<string>(), It.IsAny<char>())).Returns(numberList);
            mockConversionLogic.Setup(x => x.ConvertToStringOfNumbers(It.IsAny<List<long>>(), It.IsAny<char>())).Returns(sortedStringOfNumbers);

            return new SortingService(mockSortingRepository.Object, mockSortingLogic.Object, mockConversionLogic.Object);
        }
    }
}