using CodingTest.Interfaces;
using CodingTest.Plugins;
using CodingTest.Services;
using CodingTest.UI;

namespace CodingTest
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();

            List<IFileLoader> loaders = new List<IFileLoader>
            {
                new CsvFileLoader(),
                new TxtFileLoader(),
                new XmlFileLoader(),
            };




            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var fileLoaderService = new FileLoaderService(loaders);
            var fileWatcherService = new FileWatcherService();
            var monitoringService = new MonitoringService();

            Application.Run(new MainForm(fileLoaderService, monitoringService, fileWatcherService));
        }
    }
}