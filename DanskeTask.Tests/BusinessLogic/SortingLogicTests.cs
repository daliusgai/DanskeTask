using DanskeTask.Core.Interfaces.BusinessLogic;
using DanskeTask.Infrastructure.BusinessLogic;
using System.Collections.Generic;
using Xunit;

namespace DanskeTask.Tests
{
    public class SortingLogicTests
    {
        private readonly ISortingLogic _sortingLogic;

        public SortingLogicTests()
        {
            _sortingLogic = new SortingLogic();
        }

        [Fact]
        public void SortUsingBubbleSort_NullList_ShouldReturnNull()
        {
            List<long> numbersList = null;

            List<long> expectedReult = null;

            _sortingLogic.SortUsingBubbleSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingBubbleSort_EmptyList_ShouldReturnNull()
        {
            List<long> numbersList = new List<long>();

            List<long> expectedReult = new List<long>();

            _sortingLogic.SortUsingBubbleSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingBubbleSort_EvenSize_ShouldReturnSorted()
        {
            List<long> numbersList = new List<long>() { 1, 5, 3, 58, 76, 15 };

            List<long> expectedReult = new List<long>() { 1, 3, 5, 15, 58, 76 };

            _sortingLogic.SortUsingBubbleSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingBubbleSort_OddSize_ShouldReturnSorted()
        {
            List<long> numbersList = new List<long>() { 1, 5, 58, 76, 15 };

            List<long> expectedReult = new List<long>() { 1, 5, 15, 58, 76 };

            _sortingLogic.SortUsingBubbleSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingBubbleSort_MultipleIdenticalNumbers_ShouldReturnSorted()
        {
            List<long> numbersList = new List<long>() { 1, 5, 5, 76, 15, 1 };

            List<long> expectedReult = new List<long>() { 1, 1, 5, 5, 15, 76 };

            _sortingLogic.SortUsingBubbleSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingBubbleSort_AllIdenticalNumbers_ShouldReturnSorted()
        {
            List<long> numbersList = new List<long>() { 5, 5, 5, 5, 5 };

            List<long> expectedReult = new List<long>() { 5, 5, 5, 5, 5 };

            _sortingLogic.SortUsingBubbleSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingInsertionSort_NullList_ShouldReturnNull()
        {
            List<long> numbersList = null;

            List<long> expectedReult = null;

            _sortingLogic.SortUsingInsertionSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingInsertionSort_EmptyList_ShouldReturnNull()
        {
            List<long> numbersList = new List<long>();

            List<long> expectedReult = new List<long>();

            _sortingLogic.SortUsingInsertionSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingInsertionSort_EvenSize_ShouldReturnSorted()
        {
            List<long> numbersList = new List<long>() { 1, 5, 3, 58, 76, 15 };

            List<long> expectedReult = new List<long>() { 1, 3, 5, 15, 58, 76 };

            _sortingLogic.SortUsingInsertionSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingInsertionSort_OddSize_ShouldReturnSorted()
        {
            List<long> numbersList = new List<long>() { 1, 5, 58, 76, 15 };

            List<long> expectedReult = new List<long>() { 1, 5, 15, 58, 76 };

            _sortingLogic.SortUsingInsertionSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingInsertionSort_MultipleIdenticalNumbers_ShouldReturnSorted()
        {
            List<long> numbersList = new List<long>() { 1, 5, 5, 76, 15, 1 };

            List<long> expectedReult = new List<long>() { 1, 1, 5, 5, 15, 76 };

            _sortingLogic.SortUsingInsertionSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingInsertionSort_AllIdenticalNumbers_ShouldReturnSorted()
        {
            List<long> numbersList = new List<long>() { 5, 5, 5, 5, 5 };

            List<long> expectedReult = new List<long>() { 5, 5, 5, 5, 5 };

            _sortingLogic.SortUsingInsertionSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingQuickSort_NullList_ShouldReturnNull()
        {
            List<long> numbersList = null;

            List<long> expectedReult = null;

            _sortingLogic.SortUsingQuickSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingQuickSort_EmptyList_ShouldReturnNull()
        {
            List<long> numbersList = new List<long>();

            List<long> expectedReult = new List<long>();

            _sortingLogic.SortUsingQuickSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingQuickSort_EvenSize_ShouldReturnSorted()
        {
            List<long> numbersList = new List<long>() { 1, 5, 3, 58, 76, 15 };

            List<long> expectedReult = new List<long>() { 1, 3, 5, 15, 58, 76 };

            _sortingLogic.SortUsingQuickSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingQuickSort_OddSize_ShouldReturnSorted()
        {
            List<long> numbersList = new List<long>() { 1, 5, 58, 76, 15 };

            List<long> expectedReult = new List<long>() { 1, 5, 15, 58, 76 };

            _sortingLogic.SortUsingQuickSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingQuickSort_MultipleIdenticalNumbers_ShouldReturnSorted()
        {
            List<long> numbersList = new List<long>() { 1, 5, 5, 76, 15, 1 };

            List<long> expectedReult = new List<long>() { 1, 1, 5, 5, 15, 76 };

            _sortingLogic.SortUsingQuickSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }

        [Fact]
        public void SortUsingQuickSort_AllIdenticalNumbers_ShouldReturnSorted()
        {
            List<long> numbersList = new List<long>() { 5, 5, 5, 5, 5 };

            List<long> expectedReult = new List<long>() { 5, 5, 5, 5, 5 };

            _sortingLogic.SortUsingQuickSort(numbersList);

            Assert.Equal(expectedReult, numbersList);
        }
    }
}
