using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Stopky
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Stopwatch _sw = new Stopwatch();
        private readonly DispatcherTimer _uiTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            _uiTimer.Interval = TimeSpan.FromMilliseconds(10); // “live” update
            _uiTimer.Tick += UiTimer_Tick;

            UpdateLabel(TimeSpan.Zero);
        }

        private void UiTimer_Tick(object sender, EventArgs e)
        {
            UpdateLabel(_sw.Elapsed);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _sw.Start();
            _uiTimer.Start();

            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
            ResetButton.IsEnabled = false;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _sw.Stop();
            _uiTimer.Stop();

            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
            ResetButton.IsEnabled = true;
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            _sw.Reset();
            UpdateLabel(TimeSpan.Zero);

            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
            ResetButton.IsEnabled = false;
        }

        private void UpdateLabel(TimeSpan t)
        {
            // mm:ss.fff
            int minutes = (int)t.TotalMinutes;
            int seconds = (int)t.TotalSeconds;
            int miliseconds = (int)t.TotalMilliseconds;
            TimeLabel.Content = $"{minutes}:{seconds}.{miliseconds}";
        }
    }
}