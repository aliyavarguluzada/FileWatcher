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

            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
            var doc = await XDocument.LoadAsync(fileStream, LoadOptions.None, default);

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

            return records;
        }

        public bool CanLoad(string fileExtension)
        {
            return fileExtension.Equals(".xml", StringComparison.OrdinalIgnoreCase);
        }
    }
}
