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

                // Read the records asynchronously
                await foreach (var record in csv.GetRecordsAsync<Data>())
                {
                    records.Add(record);
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                MessageBox.Show($"Error reading file: {ex.Message}");
            }

            return records;
        }

        public bool CanLoad(string fileExtension)
        {
            return fileExtension.Equals(".csv", StringComparison.OrdinalIgnoreCase);
        }


    }
}
