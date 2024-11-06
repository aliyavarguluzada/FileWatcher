using CodingTest.Entities;
using CodingTest.Interfaces;
using System.Globalization;

namespace CodingTest.Plugins
{

    public class TxtFileLoader : IFileLoader
    {
        public async Task<List<Data>> LoadDataAsync(string filePath)
        {
            var records = new List<Data>();

            using var reader = new StreamReader(filePath);

            // Skip the header line
            await reader.ReadLineAsync();

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                var values = line.Split(';');

                if (values.Length == 6) // Make sure there are 6 columns
                {
                    var tradeData = new Data
                    {
                        Date = DateTime.Parse(values[0], CultureInfo.InvariantCulture),
                        Open = decimal.Parse(values[1], CultureInfo.InvariantCulture),
                        High = decimal.Parse(values[2], CultureInfo.InvariantCulture),
                        Low = decimal.Parse(values[3], CultureInfo.InvariantCulture),
                        Close = decimal.Parse(values[4], CultureInfo.InvariantCulture),
                        Volume = int.Parse(values[5], CultureInfo.InvariantCulture)
                    };
                    records.Add(tradeData);
                }
            }

            return records;
        }

        public bool CanLoad(string fileExtension)
        {
            return fileExtension.Equals(".txt", StringComparison.OrdinalIgnoreCase);
        }
    }

}