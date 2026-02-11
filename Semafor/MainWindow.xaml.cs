using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Semafor
{
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private int _currentIndex = 0; // 0..2

        private readonly Brush _off = Brushes.DimGray;
        private readonly Brush _red = Brushes.Red;
        private readonly Brush _orange = Brushes.Orange;
        private readonly Brush _green = Brushes.Green;

        public MainWindow()
        {
            InitializeComponent();

            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;

            SetAllOff();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
            ResetButton.IsEnabled = false;

            _timer.Start();
            ShowOnly(_currentIndex);
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
            ResetButton.IsEnabled = true;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _currentIndex = 0;
            SetAllOff();

            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
            ResetButton.IsEnabled = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // posun index
            _currentIndex++;
            if (_currentIndex > 3)
            {
                _currentIndex = 0;
            }
            ShowOnly(_currentIndex);
        }
        private void SetAllOff()
        {
            Light1.Fill = _off;
            Light2.Fill = _off;
            Light3.Fill = _off;
        }

        private void ShowOnly(int index)
        {
            SetAllOff();
            if (index == 0) Light1.Fill = _red;
            if (index == 1)
            {
                Light1.Fill = _red;
                Light2.Fill = _orange;
            }
            if (index == 2) Light3.Fill = _green;
            if (index == 3) Light2.Fill = _orange;
        }
    }
}