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

        public async void Start(int interval)
        {
            if (_isRunning)
                return;

            _monitoringTimer = new System.Windows.Forms.Timer
            {
                Interval = interval
            };
            _monitoringTimer.Tick +=  (sender, e) =>
            {
                // after changing the interval stop and start again to apply the change 
                // comment or delete the line below so it bugs you :)
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
