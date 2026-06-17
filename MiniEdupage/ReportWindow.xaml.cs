using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MiniEdupage
{
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 1. Vytvoríme si kópiu zoznamu z hlavného okna
            List<Ziak> kopiaZoznamu = new List<Ziak>(MainWindow.ziaci);

            // 2. OŠETRENIE NULOVÝCH PRIEMEROV cez klasický foreach a if
            // Prejdeme všetkých žiakov a ak niekto nemá známky (priemer je 0),
            // dáme mu fiktívny priemer 6, aby v zozname nesvietil na prvom mieste
            foreach (Ziak z in kopiaZoznamu)
            {
                if (z.PriemernaZnamka == 0)
                {
                    z.PriemernaZnamka = 6;
                }
            }

            // 3. JEDNODUCHÉ ZORADENIE
            // Teraz, keď sú nuly opravené na šestky, stačí zoznam zoradiť vzostupne od 1 po 6
            List<Ziak> zoradenyZoznam = kopiaZoznamu.OrderBy(z => z.PriemernaZnamka).ToList();

            // 4. VRÁTENIE HODNÔT SPÄŤ NA NULU
            // Aby v tabuľke žiakom nesvietil priemer 6.00 (čo je blbosť), prepíšeme tie šestky späť na 0
            foreach (Ziak z in zoradenyZoznam)
            {
                if (z.PriemernaZnamka == 6)
                {
                    z.PriemernaZnamka = 0;
                }
            }

            // 5. Priradíme kompletne pripravený zoznam do tabuľky na obrazovke
            ReportDataGrid.ItemsSource = zoradenyZoznam;
        }

        private void Zavriet_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}