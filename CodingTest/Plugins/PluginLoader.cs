using CodingTest.Interfaces;
using System.Reflection;

namespace CodingTest.Services
{
    public class PluginLoader
    {
        public static async Task<List<IFileLoader>> LoadPluginsAsync(string path)
        {
            var loaders = new List<IFileLoader>();

            await Task.Run(() =>
            {
                foreach (var dll in Directory.GetFiles(path, "*.dll"))
                {
                    var assembly = Assembly.LoadFrom(dll);
                    foreach (var type in assembly.GetTypes())
                    {
                        if (typeof(IFileLoader).IsAssignableFrom(type) && !type.IsInterface)
                        {
                            loaders.Add((IFileLoader)Activator.CreateInstance(type));
                        }
                    }
                }
            });

            return loaders;
        }
    }
}
