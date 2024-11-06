using CodingTest.UI;

namespace CodingTest.Services
{
    public class FileWatcherService
    {
        private readonly FileSystemWatcher _fileWatcher;

        public event EventHandler<FileSystemEventArgs> FileCreated;
        private bool _isRunning;

        public bool IsRunning => _isRunning;

        public FileWatcherService(string path = null)
        {
           
            if (string.IsNullOrEmpty(path))
            {
                _fileWatcher = new FileSystemWatcher()
                {
                    NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
                };
            }
            else
            {
                _fileWatcher = new FileSystemWatcher(path)
                {
                    NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
                };
            }

            _fileWatcher.Created += (s, e) => FileCreated?.Invoke(s, e);
            
        }

        public void Start()
        {
            if (string.IsNullOrEmpty(_fileWatcher.Path))
            {
                throw new InvalidOperationException("Path must be set before starting the file watcher.");
            }

            _fileWatcher.EnableRaisingEvents = true;
            _isRunning = true; // Track that the file watcher is running


        }

        public void Stop()
        {
            _fileWatcher.EnableRaisingEvents = false;
            _isRunning = false; // Track that the file watcher is stopped

        }

        public void SetPath(string path) => _fileWatcher.Path = path;
        public string GetPath() => _fileWatcher?.Path;

    }
}
