using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;

namespace Semafor
{
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private readonly DispatcherTimer _delayTimer = new DispatcherTimer();

        private int _currentIndex = 0; // 0..4
        private bool _lightsOff = false;
        private DateTime? _startTime = null;

        private readonly Random _random = new Random();

        private readonly Brush _off = Brushes.DimGray;
        private readonly Brush _on = Brushes.Red;

        public MainWindow()
        {
            InitializeComponent();

            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;

            _delayTimer.Tick += DelayTimer_Tick;

            SetAllOff();
            InfoLabel.Content = "Klikni Spusti";
        }

        private void SpustiButton_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
            InfoLabel.Content = "Priprav sa...";
            _timer.Start();
        }

        private void KlikniButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (!_lightsOff)
            {
                InfoLabel.Content = "JUMP START!";
                _timer.Stop();
                _delayTimer.Stop();
                return;
            }

            
            if (_startTime.HasValue)
            {
                double reaction =
                    (DateTime.Now - _startTime.Value).TotalMilliseconds;

                InfoLabel.Content = $"Reakčný čas: {reaction:F0} ms";
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ShowColumn(_currentIndex);
            _currentIndex++;

            if (_currentIndex > 4)
            {
                _timer.Stop();
                StartRandomDelay();
            }
        }

        private void StartRandomDelay()
        {
            int delay = _random.Next(800, 1800);
            _delayTimer.Interval = TimeSpan.FromMilliseconds(delay);
            _delayTimer.Start();
        }

        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            _delayTimer.Stop();

            SetAllOff();
            _lightsOff = true;
            _startTime = DateTime.Now;

            InfoLabel.Content = "START!";
        }

        private void ResetGame()
        {
            _timer.Stop();
            _delayTimer.Stop();

            _currentIndex = 0;
            _lightsOff = false;
            _startTime = null;

            SetAllOff();
        }

        private void SetAllOff()
        {
            Light1A.Fill = _off;
            Light1B.Fill = _off;

            Light2A.Fill = _off;
            Light2B.Fill = _off;

            Light3A.Fill = _off;
            Light3B.Fill = _off;

            Light4A.Fill = _off;
            Light4B.Fill = _off;

            Light5A.Fill = _off;
            Light5B.Fill = _off;
        }

        private void ShowColumn(int index)
        {
            if (index == 0)
            {
                Light1A.Fill = _on;
                Light1B.Fill = _on;
            }

            if (index == 1)
            {
                Light2A.Fill = _on;
                Light2B.Fill = _on;
            }

            if (index == 2)
            {
                Light3A.Fill = _on;
                Light3B.Fill = _on;
            }

            if (index == 3)
            {
                Light4A.Fill = _on;
                Light4B.Fill = _on;
            }

            if (index == 4)
            {
                Light5A.Fill = _on;
                Light5B.Fill = _on;
            }
        }
    }
}