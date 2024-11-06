using CodingTest.Entities;
using CodingTest.Interfaces;
using System.Xml.Linq;

namespace CodingTest.Plugins
{

    public class XmlFileLoader : IFileLoader
    {
        public async Task<List<Data>> LoadDataAsync(string filePath)
        {

            var records = new List<Data>();

            try
            {
                // Open the file asynchronously using a FileStream
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);

                // Load the XML document asynchronously
                var doc = await XDocument.LoadAsync(fileStream, LoadOptions.None, default);

                // Loop through XML elements and convert them to your Data model
                foreach (var element in doc.Descendants("value"))
                {
                    var tradeData = new Data
                    {
                        Date = DateTime.Parse(element.Attribute("date")?.Value),
                        Open = decimal.Parse(element.Attribute("open")?.Value),
                        High = decimal.Parse(element.Attribute("high")?.Value),
                        Low = decimal.Parse(element.Attribute("low")?.Value),
                        Close = decimal.Parse(element.Attribute("close")?.Value),
                        Volume = int.Parse(element.Attribute("volume")?.Value)
                    };

                    records.Add(tradeData);
                }
            }
            catch (Exception ex)
            {
                // Log or display error
                MessageBox.Show($"Error reading file: {ex.Message}");
            }

            return records;
        }

        public bool CanLoad(string fileExtension)
        {
            return fileExtension.Equals(".xml", StringComparison.OrdinalIgnoreCase);
        }
    }
}
