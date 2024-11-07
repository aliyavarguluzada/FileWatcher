using CodingTest.Entities;
using CodingTest.Interfaces;

namespace CodingTest.Services
{

    public class FileLoaderService
    {
        private readonly List<IFileLoader> _loaders;

        public FileLoaderService(List<IFileLoader> loaders)
        {
            _loaders = loaders;
        }

        public async Task<List<Data>> LoadFileAsync(string filePath)
        {
            var fileExtension = Path.GetExtension(filePath); // get filePath
            var loader = _loaders.FirstOrDefault(l => l.CanLoad(fileExtension)); // get right FileLoader

            if (loader != null)
            {
                return await loader.LoadDataAsync(filePath);
            }

            throw new NotSupportedException($"File format not supported: {fileExtension}");
        }
       
    }


}
