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

namespace RND_clothing_e_shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(System.IO.File.Exists("Videos/wpf projekt rnd.mp4").ToString());

            BackgroundVideo.Source = new Uri("Videos/wpf projekt rnd.mp4", UriKind.Relative);

            // LOOP
            BackgroundVideo.MediaEnded += BackgroundVideo_MediaEnded;

            BackgroundVideo.Play();
        }

        private void BackgroundVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            BackgroundVideo.Position = TimeSpan.Zero; // vráti na začiatok
            BackgroundVideo.Play(); // znova spustí
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}