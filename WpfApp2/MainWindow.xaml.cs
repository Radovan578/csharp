using System.Diagnostics.CodeAnalysis;
using System.Printing;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int cislo;
        public Random r;
        public int pokusy;
        public bool koniechry;
        public const int maxPocetPokusov = 10;
        public int poslednavzdialenost;
        public MainWindow()
        {
            InitializeComponent();
            r = new Random();
            cislo = r.Next(0, 101);
            pokusy = 0;
            koniechry = false;
            poslednavzdialenost = 0;

        }

        private void Button_Click_skus(object sender, RoutedEventArgs e)
        {
            pokusy++;
            Pokusy.Text = pokusy.ToString();
            string text = Zadanie.Text;
            int zadaneCislo = int.Parse(text);
            int aktualnavzdialenost = Math.Abs(cislo - zadaneCislo);
            if (koniechry) return;
            if (zadaneCislo == cislo)
            {
                koniechry = true;
                Info.Text = "Gratulujem vyhral si poukazku do klastora v cadci";
                pokusy = 0;
                Pokusy.Text = pokusy.ToString();
                cislo = r.Next(0, 101);
            }
            else
            {
                if (pokusy == maxPocetPokusov)
                {
                    koniechry = true;
                    Info.Text = "Koniec hry. Cislo bolo " + cislo;
                    Zadanie.Text = "";
                    pokusy = 0;
                    Pokusy.Text = pokusy.ToString();
                    cislo = r.Next(0, 101);
                    return;
                }
                if (pokusy == 1)
                {
                    if (zadaneCislo > cislo)
                    {
                        Info.Text = "Tvoje cislo: " + zadaneCislo + ", treba nizsie";
                        Zadanie.Text = "";
                    }
                    if (zadaneCislo < cislo)
                    {
                        Info.Text = "Tvoje cislo: " + zadaneCislo + ", treba vyssie";
                        Zadanie.Text = "";
                    }
                    poslednavzdialenost = aktualnavzdialenost;
                    return;
                }
                if (aktualnavzdialenost > poslednavzdialenost)
                {
                    Info.Text = Info.Text = "Tvoje cislo: " + zadaneCislo + ", Chladnejsie";
                    Zadanie.Text = "";

                }
                if (aktualnavzdialenost < poslednavzdialenost)
                {
                    Info.Text = Info.Text = "Tvoje cislo: " + zadaneCislo + ", Teplejsie";
                    Zadanie.Text = "";
                }
                if (aktualnavzdialenost == poslednavzdialenost)
                {
                    Info.Text = Info.Text = "Tvoje cislo: " + zadaneCislo + ", Rovnako";
                    Zadanie.Text = "";
                }
                poslednavzdialenost = aktualnavzdialenost;

            }

        }

        private void Button_Click_reset(object sender, RoutedEventArgs e)
        {
            cislo = r.Next(0, 101);
            pokusy = 0;
            Pokusy.Text = pokusy.ToString();
            koniechry = false;
            Info.Text = "";
            Zadanie.Text = "";
            poslednavzdialenost = 0;
        }

    }
}