using DanskeTask.Core.Interfaces.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DanskeTask.Infrastructure.BusinessLogic
{
    public class ConversionLogic : IConversionLogic
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
    }
}