using CodingTest.Entities;

namespace CodingTest.Interfaces
{
    public interface IFileLoader
    {
        Task<List<Data>> LoadDataAsync(string filePath);
        bool CanLoad(string fileExtension);
    }
}
