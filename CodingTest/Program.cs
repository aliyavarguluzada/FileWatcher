using CodingTest.Interfaces;
using CodingTest.Plugins;
using CodingTest.Services;
using CodingTest.UI;
using Microsoft.Extensions.DependencyInjection;

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

            var services = new ServiceCollection();

            // Register services
            ServiceRegistration.Register(services);

            // Build the service provider
            var serviceProvider = services.BuildServiceProvider();

            // Resolve and run the main form
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var fileLoaderService = new FileLoaderService(loaders);
            var fileWatcherService = new FileWatcherService();
            var monitoringService = new MonitoringService();
            
            //var mainForm = serviceProvider.GetRequiredService<MainForm>();

            Application.Run(new MainForm(fileLoaderService,monitoringService,fileWatcherService));
        }
    }
}