using System;
using System.Collections.Generic;
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
            // Vytvoríme si kópiu zoznamu z hlavného okna
            List<Ziak> kopiaZoznamu = new List<Ziak>(MainWindow.ziaci);

            // JEDNODUCHÉ ZORADENIE (Bubble Sort)
            // Porovnáva dvoch žiakov vedľa seba a ak má ten vpravo lepší priemer, vymení ich pozície
            for (int i = 0; i < kopiaZoznamu.Count - 1; i++)
            {
                for (int j = 0; j < kopiaZoznamu.Count - 1 - i; j++)
                {
                    double priemer1 = kopiaZoznamu[j].PriemernaZnamka;
                    double priemer2 = kopiaZoznamu[j + 1].PriemernaZnamka;

                    // Ak žiak nemá známku (priemer 0), dáme mu fiktívne číslo 6, aby skončil na konci zoznamu
                    if (priemer1 == 0)
                    {
                        priemer1 = 6;
                    }
                    if (priemer2 == 0)
                    {
                        priemer2 = 6;
                    }

                    // Chceme zoradiť od najmenšieho (1.00 je najlepší priemer)
                    if (priemer1 > priemer2)
                    {
                        Ziak docasny = kopiaZoznamu[j];
                        kopiaZoznamu[j] = kopiaZoznamu[j + 1];
                        kopiaZoznamu[j + 1] = docasny;
                    }
                }
            }

            // Priradíme utriedený zoznam do tabuľky
            ReportDataGrid.ItemsSource = kopiaZoznamu;
        }

        private void Zavriet_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}