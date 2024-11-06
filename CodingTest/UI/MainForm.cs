using CodingTest.Entities;
using CodingTest.Interfaces;
using CodingTest.Services;
using System.ComponentModel;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Timer = System.Windows.Forms.Timer;

namespace CodingTest.UI
{
    public partial class MainForm : Form
    {
        private BindingList<Data> _dataList = new BindingList<Data>();
        private FileLoaderService _fileLoaderService;
        private FileSystemWatcher _fileWatcher;
        private System.Windows.Forms.Timer _monitoringTimer;
        private List<IFileLoader> _loaders; // List to hold all file loaders


        public MainForm(FileLoaderService fileLoaderService)
        {
            InitializeComponent();
            _fileLoaderService = fileLoaderService;
            InitializeControls();
            InitializeFileWatcher();
            //_fileWatcher = new FileSystemWatcher();
            _fileWatcher = new FileSystemWatcher
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
            };
            _fileWatcher.Created += OnNewFileDetected;
        }

        private void InitializeControls()
        {

            dataGridViewDatas.DataSource = _dataList;
            dataGridViewDatas.AutoGenerateColumns = true;
            dataGridViewDatas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            MonitoringFrequencyNumeric.Value = 5; 

        }

        private void InitializeFileWatcher()
        {
            _fileWatcher = new FileSystemWatcher();
            _fileWatcher.Created += OnNewFileDetected;
        }

       

        private void StartStop_Click(object sender, EventArgs e)
        {
            if (_monitoringTimer == null)
                StartMonitoring();
            else
                StopMonitoring();



        }

        private void SetPath_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = folderBrowserDialog.SelectedPath;

                    _fileWatcher.Path = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void MonitoringFrequencyNumeric_ValueChanged(object sender, EventArgs e)
        {
            var newFrequency = MonitoringFrequencyNumeric.Value;


            Debug.WriteLine($"Monitoring frequency set to: {newFrequency}");
        }
        private void StartStopMonitoring_Click(object sender, EventArgs e)
        {

        }
        private bool StartMonitoring()
        {
            _monitoringTimer = new Timer();
            _monitoringTimer.Interval = (int)MonitoringFrequencyNumeric.Value * 1000;
            _monitoringTimer.Tick += (s, e) => _fileWatcher.EnableRaisingEvents = true;
            _monitoringTimer.Start();

            StartStopMonitoring.Text = "Stop Monitoring";
            StartStopMonitoring.Text = "Monitoring started...";

            return true;
        }

        private bool StopMonitoring()
        {
            _monitoringTimer?.Stop();
            _monitoringTimer = null;
            _fileWatcher.EnableRaisingEvents = true;

            StartStopMonitoring.Text = "Start Monitoring";
            StartStopMonitoring.Text = "Monitoring stopped.";
            return true;
        }
        private void OnNewFileDetected(object sender, FileSystemEventArgs e)
        {
            Task.Run(() => LoadFileData(e.FullPath));
        }
        private async void LoadFileData(string filePath)
        {
            try
            {
                var data = await _fileLoaderService.LoadFileAsync(filePath);
                Invoke((Action)(() =>
                {
                    foreach (var item in data)
                    {
                        _dataList.Add(item);
                    }
                }));

                Invoke((Action)(() => DirectoryPath.Text = $"Loaded: {Path.GetFileName(filePath)}"));
            }
            catch (Exception ex)
            {
                Invoke((Action)(() => MessageBox.Show($"Error loading file: {ex.Message}")));
            }
        }
        //private async void OnNewFileDetected(object sender, FileSystemEventArgs e)
        //{
        //    // Only process the new file if it is of a known format
        //    string extension = Path.GetExtension(e.FullPath);
        //    var loader = GetFileLoader(extension);

        //    if (loader != null)
        //    {
        //        List<Data> data = await loader.LoadDataAsync(e.FullPath);

        //        // Use Invoke to update UI from a non-UI thread
        //        Invoke((Action)(() =>
        //        {
        //            _dataList.Clear();
        //            foreach (var item in data)
        //            {
        //                _dataList.Add(item);
        //            }
        //        }));
        //    }
        //}
        private IFileLoader GetFileLoader(string fileExtension)
        {
            return _loaders.FirstOrDefault(loader => loader.CanLoad(fileExtension));
        }
        private void dataGridViewDatas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
