using System;
using System.IO;
using System.Text;
using System.Text.Json; // NOVÝ RIADOK: Knižnica, ktorá robí celú mágiu s JSON
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MiniEdupage
{
    public partial class MainWindow : Window
    {
        public static List<Ziak> ziaci = new List<Ziak>();

        // ZMENA: Zmenili sme koncovku súboru na .json, aby to bolo profesionálne
        string nazovSuboru = "ziaci_data.json";

        public MainWindow()
        {
            InitializeComponent();

            // Automaticky načítame staré dáta zo súboru hneď, ako sa zapne aplikácia
            NacitatDataZoSuboru();
        }

        public void AddZiak_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        public void AddZiakButton_Click(object sender, RoutedEventArgs e)
        {
            string ziakName = AddZiakTextBox.Text;

            if (ziakName != "" && ziakName != "Zadaj meno ziaka...")
            {
                Ziak newZiak = new Ziak();
                newZiak.Name = ziakName;

                ziaci.Add(newZiak);

                // Aktualizujeme zoznam na obrazovke
                ObnovZoznamNaObrazovke();
                AddZiakTextBox.Text = "Zadaj meno ziaka...";
            }
        }

        public void AddZiakTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (AddZiakTextBox.Text == "Zadaj meno ziaka...")
            {
                AddZiakTextBox.Text = "";
            }
        }

        public void AddZiakTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AddZiakTextBox.Text == "")
            {
                AddZiakTextBox.Text = "Zadaj meno ziaka...";
            }
        }

        public void ZiaciListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UkazDetailVybranehoZiaka();
        }

        public void PridatZnamku_Click(object sender, RoutedEventArgs e)
        {
            Ziak vybranyZiak = (Ziak)ZiaciListBox.SelectedItem;

            if (vybranyZiak != null)
            {
                ComboBoxItem vybranyRiadok = (ComboBoxItem)ZnamkaComboBox.SelectedItem;

                if (vybranyRiadok != null)
                {
                    string cisloText = vybranyRiadok.Content.ToString();
                    int novaZnamka = int.Parse(cisloText);

                    // Pridáme známku do listu žiaka
                    vybranyZiak.Znamky.Add(novaZnamka);

                    // Prepočítame mu počet a priemer známok
                    PrepocitajZiakoviStatistiky(vybranyZiak);

                    // Obnovíme texty na obrazovke
                    UkazDetailVybranehoZiaka();
                }
            }
        }

        // Pomocná funkcia na výpočet počtu a priemeru bez zložitých skratiek
        public void PrepocitajZiakoviStatistiky(Ziak ziak)
        {
            int pocet = ziak.Znamky.Count;
            ziak.PocetZnamok = pocet;

            if (pocet > 0)
            {
                double sucet = 0;
                foreach (int znamka in ziak.Znamky)
                {
                    sucet = sucet + znamka;
                }
                double priemer = sucet / pocet;
                ziak.PriemernaZnamka = Math.Round(priemer, 2);
            }
            else
            {
                ziak.PriemernaZnamka = 0.0;
            }
        }

        // Pomocná funkcia na zobrazenie informácií v pravom paneli
        public void UkazDetailVybranehoZiaka()
        {
            Ziak vybranyZiak = (Ziak)ZiaciListBox.SelectedItem;

            if (vybranyZiak != null)
            {
                MenoZiakaTextBlock.Text = vybranyZiak.Name;
                PocetZnamokTextBlock.Text = vybranyZiak.PocetZnamok.ToString();

                // Priemer na 2 desatinné miesta
                PriemerTextBlock.Text = vybranyZiak.PriemernaZnamka.ToString("0.00");

                // Vytvoríme textový zoznam známok oddelených čiarkou
                string textZnamok = "";
                foreach (int z in vybranyZiak.Znamky)
                {
                    if (textZnamok == "")
                    {
                        textZnamok = z.ToString();
                    }
                    else
                    {
                        textZnamok = textZnamok + ", " + z.ToString();
                    }
                }
                ZnamkyTextBlock.Text = textZnamok;
            }
            else
            {
                MenoZiakaTextBlock.Text = "-";
                ZnamkyTextBlock.Text = "-";
                PocetZnamokTextBlock.Text = "0";
                PriemerTextBlock.Text = "0.00";
            }
        }

        // Pomocná funkcia na obnovenie zoznamu
        public void ObnovZoznamNaObrazovke()
        {
            ZiaciListBox.ItemsSource = null;
            ZiaciListBox.ItemsSource = ziaci;
        }

        // PREROBENÉ NA JSON: Tlačidlo na uloženie dát
        public void UlozitData_Click(object sender, RoutedEventArgs e)
        {
            // 1. Zoberieme celý náš List<Ziak> a premeníme ho na jeden veľký JSON text
            string jsonText = JsonSerializer.Serialize(ziaci);

            // 2. Tento jeden text rovno zapíšeme do súboru
            File.WriteAllText(nazovSuboru, jsonText);

            // Ak to nevolalo mazanie žiaka (čiže sender nie je null), ukážeme hlášku
            if (sender != null)
            {
                MessageBox.Show("Dáta boli úspešne uložené do JSON súboru!");
            }
        }

        // PREROBENÉ NA JSON: Funkcia, ktorá hneď pri zapnutí načíta dáta
        public void NacitatDataZoSuboru()
        {
            if (File.Exists(nazovSuboru))
            {
                // 1. Prečítame celý JSON text zo súboru
                string jsonText = File.ReadAllText(nazovSuboru);

                // 2. Povieme C#, nech ten text premení späť na List<Ziak>
                List<Ziak> nacitaniZiaci = JsonSerializer.Deserialize<List<Ziak>>(jsonText);

                if (nacitaniZiaci != null)
                {
                    ziaci = nacitaniZiaci;
                }

                // Obnovíme zoznam na obrazovke
                ObnovZoznamNaObrazovke();
            }
        }

        public void OdstranitZiakButton_Click(object sender, RoutedEventArgs e)
        {
            Ziak vybranyZiak = (Ziak)ZiaciListBox.SelectedItem;

            if (vybranyZiak != null)
            {
                ziaci.Remove(vybranyZiak);
                ObnovZoznamNaObrazovke();
                UkazDetailVybranehoZiaka();

                // Tu voláme tvoje skvelé vylepšenie, ktoré uloží zmeny aj po zmazaní
                UlozitData_Click(null, null);
            }
            else
            {
                MessageBox.Show("Najprv kliknutím vyber žiaka zo zoznamu, ktorého chceš odstrániť.");
            }
        }

        public void VygenerovatReport_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow okno = new ReportWindow();
            okno.ShowDialog();
        }
    }
}