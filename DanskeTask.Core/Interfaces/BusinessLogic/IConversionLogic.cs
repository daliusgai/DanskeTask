using System.Collections.Generic;

namespace DanskeTask.Core.Interfaces.BusinessLogic
{
    public interface IConversionLogic
    {
        List<long> ConvertToListOfNumbers(string stringOfNumbers, char delimiter);

        string ConvertToStringOfNumbers(IEnumerable<long> numbersList, char delimiter);
    }
}