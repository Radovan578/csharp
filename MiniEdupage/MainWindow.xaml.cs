using System;
using System.IO; // TOTO JE TEN SYSTEM IO. Vďaka nemu vie program ukladať a načítať dáta z disku!
using System.Text;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MiniEdupage
{
    public partial class MainWindow : Window
    {
        public static List<Ziak> ziaci = new List<Ziak>();

        string nazovSuboru = "ziaci_data.txt";

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

            if (ziakName != "")
            {
                if (ziakName != "Zadaj meno ziaka...")
                {
                    Ziak newZiak = new Ziak();
                    newZiak.Name = ziakName;

                    ziaci.Add(newZiak);

                    // Aktualizujeme zoznam na obrazovke
                    ObnovZoznamNaObrazovke();
                    AddZiakTextBox.Text = "Zadaj meno ziaka...";
                }
            }
        }
        public void AddZiakTextBox_GotFocus(object sender, RoutedEventArgs e)
{
    // Ak je v poli stále pôvodný text, tak ho vymažeme, aby mohol používateľ rovno písať
    if (AddZiakTextBox.Text == "Zadaj meno ziaka...")
    {
        AddZiakTextBox.Text = "";
    }
}

// Táto funkcia sa spustí, keď KLIKNEŠ MIMO textového poľa
public void AddZiakTextBox_LostFocus(object sender, RoutedEventArgs e)
{
    // Ak používateľ nič nenapísal a klikol preč, vrátime tam pôvodný text
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
                MenoZiadkaTextBlock.Text = vybranyZiak.Name;
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
                MenoZiadkaTextBlock.Text = "-";
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

        // Tlačidlo na uloženie dát do textového súboru
        public void UlozitData_Click(object sender, RoutedEventArgs e)
        {
            List<string> riadkyNaUlozenie = new List<string>();

            foreach (Ziak z in ziaci)
            {
                // Najprv vyrobíme text zo známok (napríklad "1,2,5")
                string znamkyText = "";
                foreach (int znamka in z.Znamky)
                {
                    if (znamkyText == "")
                    {
                        znamkyText = znamka.ToString();
                    }
                    else
                    {
                        znamkyText = znamkyText + "," + znamka.ToString();
                    }
                }

                // Spojíme meno a známky pomocou bodkočiarky: "Janko Novák;1,2,5"
                string riadok = z.Name + ";" + znamkyText;
                riadkyNaUlozenie.Add(riadok);
            }

            File.WriteAllLines(nazovSuboru, riadkyNaUlozenie);
            MessageBox.Show("Dáta boli úspešne uložené!");
        }

        // Funkcia, ktorá hneď pri zapnutí načíta textový súbor
        public void NacitatDataZoSuboru()
        {
            if (File.Exists(nazovSuboru))
            {
                string[] riadky = File.ReadAllLines(nazovSuboru);
                ziaci.Clear();

                foreach (string riadok in riadky)
                {
                    string[] casti = riadok.Split(';');
                    if (casti.Length >= 2)
                    {
                        Ziak z = new Ziak();
                        z.Name = casti[0];

                        string znamkyText = casti[1];
                        if (znamkyText != "")
                        {
                            string[] cislaZnamok = znamkyText.Split(',');
                            foreach (string cislo in cislaZnamok)
                            {
                                int oplatka = int.Parse(cislo);
                                z.Znamky.Add(oplatka);
                            }
                        }

                        // Prepočítame načítanému žiakovi štatistiky
                        PrepocitajZiakoviStatistiky(z);
                        ziaci.Add(z);
                    }
                }
                ObnovZoznamNaObrazovke();
            }
        }
        public void OdstranitZiakButton_Click(object sender, RoutedEventArgs e)
        {
            // 1. Zistíme, ktorý žiak je práve označený v zozname
            Ziak vybranyZiak = (Ziak)ZiaciListBox.SelectedItem;

            // 2. Skontrolujeme, či používateľ naozaj nejakého žiaka vybral
            if (vybranyZiak != null)
            {
                // 3. Odstránime ho z nášho hlavného zoznamu v pamäti
                ziaci.Remove(vybranyZiak);

                // 4. Aktualizujeme zoznam na obrazovke, aby odtiaľ žiak zmizol
                ObnovZoznamNaObrazovke();

                // 5. Vyčistíme pravý panel s detailmi, keďže daný žiak už neexistuje
                UkazDetailVybranehoZiaka();

                UlozitData_Click(null, null);
            }
            else
            {
                // Ak klikne na tlačidlo a nemá vybraného žiadneho žiaka, upozorníme ho
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