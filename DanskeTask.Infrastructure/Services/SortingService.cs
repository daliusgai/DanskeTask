using DanskeTask.Core.DTO;
using DanskeTask.Core.Enumerators;
using DanskeTask.Core.Interfaces.BusinessLogic;
using DanskeTask.Core.Interfaces.Repositories;
using DanskeTask.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DanskeTask.Infrastructure.Services
{
    public class SortingService : ISortingService
    {
        private readonly ISortingRepository _sortingRepository;
        private readonly ISortingLogic _sortingLogic;
        private readonly IConversionLogic _conversionLogic;

        public SortingService(ISortingRepository sortingRepository, ISortingLogic sortingLogic, IConversionLogic conversionLogic)
        {
            _sortingRepository = sortingRepository;
            _sortingLogic = sortingLogic;
            _conversionLogic = conversionLogic;
        }

        public SortResponseDTO Sort(string stringOfNumbers) 
        {
            try
            {
                var numberList = _conversionLogic.ConvertToListOfNumbers(stringOfNumbers, ' ');

                var firstCopyOfNumberList = new List<long>(numberList);
                var secondCopyOfNumberList = new List<long>(numberList);
                var thirdCopyOfNumberList = new List<long>(numberList);

                var firstResult = SortUsingAlgorithm(ESortingAlgorithms.BubbleSort, firstCopyOfNumberList);
                var secondResult = SortUsingAlgorithm(ESortingAlgorithms.InsertionSort, secondCopyOfNumberList);
                var thirdResult = SortUsingAlgorithm(ESortingAlgorithms.QuickSort, thirdCopyOfNumberList);

                var stringOfOrderedNumbers = _conversionLogic.ConvertToStringOfNumbers(firstCopyOfNumberList, ' ');
                _sortingRepository.SaveSortedNumbers(stringOfOrderedNumbers);

                return new SortResponseDTO() 
                { 
                    SortedNumbers = stringOfOrderedNumbers,
                    AlgortihmPerformance = new List<SortAlgorithmResponseDTO>() { firstResult, secondResult, thirdResult }
                };
            }
            catch 
            {
                return null;
            }
        }

        public GetLatestSortResultResponseDTO GetLatestSortResult() 
        {
            try
            {
                var latestNumbers = _sortingRepository.GetLatestSortResult();

                return new GetLatestSortResultResponseDTO() { SortedNumbers = latestNumbers };
            }
            catch
            {
                return null;
            }
        }

        private SortAlgorithmResponseDTO SortUsingAlgorithm(ESortingAlgorithms eSortingAlgorithm, List<long> numberList) 
        {
            Stopwatch stopwatch = null;

            switch (eSortingAlgorithm) 
            {
                case ESortingAlgorithms.BubbleSort:
                    stopwatch = Stopwatch.StartNew();
                    _sortingLogic.SortUsingBubbleSort(numberList);
                    stopwatch.Stop();
                    break;
                case ESortingAlgorithms.InsertionSort:
                    stopwatch = Stopwatch.StartNew();
                    _sortingLogic.SortUsingBubbleSort(numberList);
                    stopwatch.Stop();
                    break;
                case ESortingAlgorithms.QuickSort:
                    stopwatch = Stopwatch.StartNew();
                    _sortingLogic.SortUsingBubbleSort(numberList);
                    stopwatch.Stop();
                    break;
                default:
                    break;
            }

            return new SortAlgorithmResponseDTO()
            {
                AlgorithmTitle = Enum.GetName(typeof(ESortingAlgorithms), eSortingAlgorithm),
                DurationInMiliseconds = stopwatch.Elapsed.TotalMilliseconds
            };
        }
    }
}