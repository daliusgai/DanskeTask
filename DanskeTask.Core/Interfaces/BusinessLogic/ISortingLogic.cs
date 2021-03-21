using System.Collections.Generic;

namespace DanskeTask.Core.Interfaces.Services
{
    public interface ISortingLogic
    {
        List<long> ConvertToListOfNumbers(string stringOfNumbers, char delimiter);

        string ConvertToStringOfNumbers(IEnumerable<long> numbersList, char delimiter);

        void SortUsingBubbleSort(List<long> numberList);

        void SortUsingInsertionSort(List<long> numberList);

        void SortUsingQuickSort(List<long> numberList);
    }
}