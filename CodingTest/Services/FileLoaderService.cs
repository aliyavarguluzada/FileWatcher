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
            var fileExtension = Path.GetExtension(filePath);
            var loader = _loaders.FirstOrDefault(l => l.CanLoad(fileExtension));

            if (loader != null)
            {
                return await loader.LoadDataAsync(filePath);
            }

            //MessageBox.Show($"File format not supported: {fileExtension}");
            throw new NotSupportedException($"File format not supported: {fileExtension}");
        }
       
    }


}
