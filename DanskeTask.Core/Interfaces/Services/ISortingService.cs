using DanskeTask.Core.DTO;

namespace DanskeTask.Core.Interfaces.Services
{
    public interface ISortingService
    {
        SortResponseDTO Sort(string stringOfNumbers);

        GetLatestSortResultResponseDTO GetLatestSortResult();
    }
}