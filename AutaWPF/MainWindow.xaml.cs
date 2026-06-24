using System.Text;
using System.Text.Json;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Auto auto1 = new Auto("BA-123AB", 152400, 0.35, 0, 0, 0);
        Auto auto2 = new Auto("ZA-421CD", 125000, 0.40, 0, 0, 0);
        Auto auto3 = new Auto("KO-235FA", 143000, 0.25, 0, 0, 0);
        Auto auto4 = new Auto("PU-798PM", 182300, 0.30, 0, 0, 0);
        Auto auto5 = new Auto("SA-094LM", 178400, 0.15, 0, 0, 0);
        List<Auto> cars = new List<Auto>();

        string nazovSuboru = "cars_data.json";

        public MainWindow()
        {
            cars.Add(auto1);
            cars.Add(auto2);
            cars.Add(auto3);
            cars.Add(auto4);
            cars.Add(auto5);

            InitializeComponent();
            CarCombox_SPZPicker.ItemsSource = cars;
            //NacitatDataZoSuboru();
        }

        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var auto = CarCombox_SPZPicker.SelectedItem as Auto;
            if (auto != null)
            {
                StartKMTextBox.Text = auto.StartKM.ToString();
            }
        }
        public void StartKM_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        public void AddKM_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            string newCarKM = AddCarTextBox.Text;
            var auto = CarCombox_SPZPicker.SelectedItem as Auto;
            if (auto != null && newCarKM != "" && newCarKM != "napr. 152300")
            {
                
                auto.EndKM = int.Parse(newCarKM);
                AddCarTextBox.Text = "napr. 152300";

                int vypocet = auto.EndKM - auto.StartKM;
                auto.NajazdeneKM = vypocet;

                double cena = auto.NajazdeneKM * auto.CenaZaKM;
                auto.Cena = cena;

                Listik.Items.Add(auto.SPZ + "              " + auto.StartKM + "            " + auto.EndKM + "              " + auto.NajazdeneKM + "             " + auto.Cena);
            }
        }
        public void AddCarTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (AddCarTextBox.Text == "napr. 152300")
            {
                AddCarTextBox.Text = "";
            }
        }

        public void AddCarTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AddCarTextBox.Text == "")
            {
                AddCarTextBox.Text = "napr. 152300";
            }
        }
        public void UlozitData_Click(object sender, RoutedEventArgs e)
        {
            string jsonText = JsonSerializer.Serialize(cars);

            File.WriteAllText(nazovSuboru, jsonText);

            if (sender != null)
            {
                MessageBox.Show("Dáta boli úspešne uložené do JSON súboru!");
            }
        }
        public void NacitatDataZoSuboru()
        {
            if (File.Exists(nazovSuboru))
            {
                string jsonText = File.ReadAllText(nazovSuboru);

                List<Auto> nacitaneAuta = JsonSerializer.Deserialize<List<Auto>>(jsonText);

                if (nacitaneAuta != null)
                {
                    cars = nacitaneAuta;
                }

                ObnovZoznamNaObrazovke();
            }
        }
        public void ObnovZoznamNaObrazovke()
        {
            Listik.ItemsSource = null;
            Listik.ItemsSource = cars;
        }

        
    } 
}