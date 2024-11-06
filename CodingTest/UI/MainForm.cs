using CodingTest.Entities;
using CodingTest.Interfaces;
using CodingTest.Services;
using System.ComponentModel;

namespace CodingTest.UI
{
    public partial class MainForm : Form
    {
        private BindingList<Data> _dataList = new BindingList<Data>();
        private FileLoaderService _fileLoaderService;
        private readonly FileWatcherService _fileWatcherService;
        private readonly MonitoringService _monitoringService;
        private System.Windows.Forms.Timer _monitoringTimer;
        private List<IFileLoader> _loaders;


        public MainForm(FileLoaderService fileLoaderService,
                        MonitoringService monitoringService,
                        FileWatcherService fileWatcherService)
        {
            _fileLoaderService = fileLoaderService;
            _monitoringService = monitoringService;
            _fileWatcherService = fileWatcherService;

            InitializeComponent();
            InitializeControls();

            _fileWatcherService.FileCreated += OnNewFileDetected;

        }





        private void StartStop_Click(object sender, EventArgs e)
        {
            // Check if the file path is set for file watcher service
            if (string.IsNullOrEmpty(_fileWatcherService.GetPath()))
            {
                MessageBox.Show("Please set the directory path first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Prevent starting if path is not set
            }

            // Start or stop the monitoring service
            if (!_monitoringService.IsRunning)
            {
                _monitoringService.Start((int)MonitoringFrequencyNumeric.Value * 1000);
                StartStopMonitoring.Text = "Stop Monitoring";
                _fileWatcherService.Start();
            }
            else
            {
                _monitoringService.Stop();
                StartStopMonitoring.Text = "Start Monitoring";
            }


        }


        private void SetPath_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = folderBrowserDialog.SelectedPath;
                    _fileWatcherService.SetPath(folderBrowserDialog.SelectedPath);

                }
            }
        }

        private void MonitoringFrequencyNumeric_ValueChanged(object sender, EventArgs e) =>
            _monitoringService.SetInterval((int)MonitoringFrequencyNumeric.Value * 1000);



        private async void OnNewFileDetected(object sender, FileSystemEventArgs e)
        {
            if (_monitoringService.IsRunning)
            {
                Task.Run(() => LoadFileData(e.FullPath));
            }
        }


        private async void LoadFileData(string filePath)
        {
            try
            {
                var data = await _fileLoaderService.LoadFileAsync(filePath);

                // Once data is loaded, update the DataGridView
                Invoke((Action)(() =>
                {
                    dataGridViewDatas.DataSource = new BindingList<Data>(data);
                }));

                // Optionally show a message about the loaded file
                // Might delete later this line is not mandatory :)
                Invoke((Action)(() =>
                {
                    DirectoryPath.Text = $"Loaded: {Path.GetFileName(filePath)}";
                }));
                MessageBox.Show("File loaded");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading file: {ex.Message}");
            }
        }

        private IFileLoader GetFileLoader(string fileExtension)
            => _loaders.FirstOrDefault(loader => loader.CanLoad(fileExtension));

        private void dataGridViewDatas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void StartStopMonitoring_Click(object sender, EventArgs e)
        {

        }
    }
}
