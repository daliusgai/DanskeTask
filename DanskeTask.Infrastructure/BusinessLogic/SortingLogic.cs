using DanskeTask.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DanskeTask.Infrastructure.BusinessLogic
{
    public class SortingLogic : ISortingLogic
    {
        public List<long> ConvertToListOfNumbers(string stringOfNumbers, char delimiter) 
        {
            var listOfNumbersAsString = stringOfNumbers.Split(delimiter).ToList();

            return listOfNumbersAsString.ConvertAll(x => Convert.ToInt64(x)).ToList();
        }

        public string ConvertToStringOfNumbers(IEnumerable<long> numbersList, char delimiter)
        {
            return string.Join(delimiter.ToString(), numbersList);
        }

        public void SortUsingBubbleSort(List<long> numberList)
        {
            if (numberList is null || !numberList.Any())
                return;

            int swapIterations, sortIterations;
            int listSize = numberList.Count;

            for (sortIterations = listSize - 1; sortIterations > 0; sortIterations--)
            {
                for (swapIterations = 0; swapIterations < sortIterations; swapIterations++)
                {
                    if (numberList[swapIterations] > numberList[swapIterations + 1])
                        Swap(numberList, swapIterations, swapIterations + 1);
                }
            }
        }

        public void SortUsingInsertionSort(List<long> numberList) 
        {
            if (numberList is null || !numberList.Any())
                return;

            int swapIterations, sortIterations;
            int listSize = numberList.Count;

            for (sortIterations = 1; sortIterations < listSize; sortIterations++)
            {
                for (swapIterations = sortIterations; swapIterations > 0 && numberList[swapIterations] < numberList[swapIterations - 1]; swapIterations--)
                {
                    Swap(numberList, swapIterations, swapIterations - 1);
                }
            }
        }

        public void SortUsingQuickSort(List<long> numberList)
        {
            if (numberList is null || !numberList.Any())
                return;

            SortUsingQuickSort(numberList, 0, numberList.Count - 1);
        }

        private void SortUsingQuickSort(List<long> numberList, int leftPointer, int rightPointer) 
        {
            int newLeftPointer, newRightPointer;
            long pivot;

            newLeftPointer = leftPointer;
            newRightPointer = rightPointer;

            pivot = numberList[(leftPointer + rightPointer) / 2];
            while (true)
            {
                while (numberList[newLeftPointer] < pivot)
                    newLeftPointer++;
                while (pivot < numberList[newRightPointer])
                    newRightPointer--;
                if (newLeftPointer <= newRightPointer)
                {
                    Swap(numberList, newLeftPointer, newRightPointer);
                    newLeftPointer++;
                    newRightPointer--;
                }
                if (newLeftPointer > newRightPointer)
                    break;
            }
            if (leftPointer < newRightPointer)
                SortUsingQuickSort(numberList, leftPointer, newRightPointer);
            if (newLeftPointer < rightPointer)
                SortUsingQuickSort(numberList, newLeftPointer, rightPointer);
        }


        private void Swap(List<long> data, int firstPosition, int secondPosition)
        {
            long temporary;

            temporary = data[firstPosition];
            data[firstPosition] = data[secondPosition];
            data[secondPosition] = temporary;
        }
    }
}