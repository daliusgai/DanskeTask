namespace DanskeTask.Core.Interfaces.Repositories
{
    public interface ISortingRepository
    {
        void SaveSortedNumbers(string stringOfNumbers);

        string GetLatestSortResult();
    }
}