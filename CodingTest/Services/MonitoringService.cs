namespace CodingTest.Services
{
    public class MonitoringService
    {

        public void SetInterval(int interval)
        {
            if (_monitoringTimer != null)
            {
                _monitoringTimer.Interval = interval;
            }
        }
        private System.Windows.Forms.Timer _monitoringTimer;
        private bool _isRunning;

        public bool IsRunning => _isRunning;

        public void Start(int interval)
        {
            if (_isRunning)
                return;

            _monitoringTimer = new System.Windows.Forms.Timer
            {
                Interval = interval
            };
            _monitoringTimer.Tick += (sender, e) =>
            {
                // Logic for monitoring, for example, checking files or data every interval
                //MessageBox.Show($"Interval is: {interval / 1000}");
            };
            _monitoringTimer.Start();
            _isRunning = true;
        }

        public void Stop()
        {
            if (!_isRunning)
                return;

            _monitoringTimer.Stop();
            _isRunning = false;
        }
    }
}
