using System.Collections.Generic;

namespace DanskeTask.Core.DTO
{
    public class SortResponseDTO
    {
        public string SortedNumbers { get; set; }

        public List<SortAlgorithmResponseDTO> AlgortihmPerformance { get; set; }
    }
}