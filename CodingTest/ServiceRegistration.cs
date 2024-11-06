using CodingTest.Interfaces;
using CodingTest.Plugins;
using CodingTest.Services;
using CodingTest.UI;
using CsvHelper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CodingTest
{
    public static class ServiceRegistration
    {
        public static void Register(this IServiceCollection services)
        {
            List<IFileLoader> loaders = new List<IFileLoader>
            {
                new CsvFileLoader(),
                new TxtFileLoader(),
                new XmlFileLoader(),
            };
            var fileLoaderService = new FileLoaderService(loaders);

            services.AddSingleton<MainForm>();

            // Register your custom services
            services.AddSingleton<FileWatcherService>();       // Adjust to transient if needed
            services.AddSingleton<MonitoringService>();        // Adjust to transient if needed

            // Add loaders if they’re used in FileLoaderService
            services.AddSingleton<IFileLoader, CsvFileLoader>();
            services.AddSingleton<IFileLoader, TxtFileLoader>();
            services.AddSingleton<IFileLoader, XmlFileLoader>();

        }
    }
}
