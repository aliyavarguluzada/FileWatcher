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
            var records = new List<Data>();

            try
            {
                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                await foreach (var record in csv.GetRecordsAsync<Data>())
                {
                    records.Add(record);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
            }

            return records;
        }

        public bool CanLoad(string fileExtension) =>
            fileExtension.Equals(".csv", StringComparison.OrdinalIgnoreCase);



    }
}
