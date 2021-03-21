using System.Collections.Generic;

namespace DanskeTask.Core.Interfaces.BusinessLogic
{
    public interface ISortingLogic
    {
        void SortUsingBubbleSort(List<long> numberList);

        void SortUsingInsertionSort(List<long> numberList);

        void SortUsingQuickSort(List<long> numberList);
    }
}