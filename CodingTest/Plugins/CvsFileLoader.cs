using CodingTest.Entities;
using CodingTest.Interfaces;
using CsvHelper;
using System.Globalization;

namespace CodingTest.Plugins
{
    public class CsvFileLoader : IFileLoader
    {
        public async Task<List<Data>> LoadDataAsync(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = new List<Data>();

            await foreach (var record in csv.GetRecordsAsync<Data>())
            {
                records.Add(record);
            }

            return records;
        }

        public bool CanLoad(string fileExtension)
        {
            return fileExtension.Equals(".csv", StringComparison.OrdinalIgnoreCase);
        }


    }
}
