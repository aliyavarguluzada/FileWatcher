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

            var fileLoaderService = new FileLoaderService(loaders);
            //var pluginLoaders =  PluginLoader.LoadPluginsAsync("Plugins");
            //loaders.AddRange(pluginLoaders); fix pluginLoader 
            Application.Run(new MainForm(fileLoaderService));
        }
    }
}