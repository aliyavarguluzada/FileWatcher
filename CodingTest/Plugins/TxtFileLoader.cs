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

            try
            {
                using var reader = new StreamReader(filePath);

                await reader.ReadLineAsync();

                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    var values = line.Split(';');

                    if (values.Length == 6) // looks for 6 columns as described in the pdf 
                    {
                        var data = new Data
                        {
                            Date = DateTime.Parse(values[0], CultureInfo.InvariantCulture),
                            Open = decimal.Parse(values[1], CultureInfo.InvariantCulture),
                            High = decimal.Parse(values[2], CultureInfo.InvariantCulture),
                            Low = decimal.Parse(values[3], CultureInfo.InvariantCulture),
                            Close = decimal.Parse(values[4], CultureInfo.InvariantCulture),
                            Volume = int.Parse(values[5], CultureInfo.InvariantCulture)
                        };
                        records.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
            }

            return records;
        }

        public bool CanLoad(string fileExtension) =>
             fileExtension.Equals(".txt", StringComparison.OrdinalIgnoreCase);

    }

}