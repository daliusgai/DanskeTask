using DanskeTask.Core.Interfaces.Repositories;
using System;
using System.IO;
using System.Linq;

namespace DanskeTask.Infrastructure.Services
{
    public class SortingRepository : ISortingRepository
    {
        private readonly string _fileExtension = ".txt";
        private readonly string _folder = AppDomain.CurrentDomain.BaseDirectory;

        public SortingRepository()
        {
        }

        public void SaveSortedNumbers(string stringOfNumbers)
        {
            string filename = $"{ _folder }{ DateTimeOffset.Now.ToUnixTimeSeconds() }{ _fileExtension }";

            File.WriteAllText(filename, stringOfNumbers);
        }

        public string GetLatestSortResult()
        {
            string filter = $"*{_fileExtension}";
            var files = Directory.GetFiles(_folder, filter).ToList();

            var mostRecentFileTimestamp = files.ConvertAll(x => x.Replace(_fileExtension, "")).ToList().Max();
            var mostRecentFile = $"{mostRecentFileTimestamp}{_fileExtension}";
            return File.ReadAllText($"{mostRecentFile}");
        }
    }
}