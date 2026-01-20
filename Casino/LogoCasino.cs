using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class LogoCasino
    {
        private int positionX = 55;
        private int positionX2 = 35;
        private int positionY = 25;
        private string logo = nameof(LoadingUI);

        public void StartUI()
        {
            // Spustí animáciu načítavania loga a zablokuje kurzor
            Console.CursorVisible = false;
            LoadingUI();

        }
        private void LogoCSN()
        {
            // Vykreslí ASCII logo v strede konzoly
            string[] lines = new string[]
            {
"  ██████╗ █████╗ ███████╗██╗███╗   ██╗ ██████╗ ",
" ██╔════╝██╔══██╗██╔════╝██║████╗  ██║██╔═══██╗",
" ██║     ███████║███████╗██║██╔██╗ ██║██║   ██║",
" ██║     ██╔══██║╚════██║██║██║╚██╗██║██║   ██║",
" ╚██████╗██║  ██║███████║██║██║ ╚████║╚██████╔╝",
"  ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝╚═╝  ╚═══╝ ╚═════╝ ",
" ",
"           ★★★  CASINO ADMIRAL  ★★★        "
            };

            int startY = (Console.WindowHeight / 2) - (lines.Length / 2) - 2;
            int widthConsole = Console.WindowWidth;

            for (int i = 0; i < lines.Length; i++)
            {
                // Vypočíta pozíciu, kde sa má každý riadok vykresliť
                string line = lines[i];
                int xStart = (widthConsole / 2) - (line.Length / 2);
                if (xStart < 0) xStart = 0;
                int y = startY + i;
                if (y < 0) y = 0;
                try
                {
                    Console.SetCursorPosition(xStart, y);
                    Console.WriteLine(line);
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Ak je konzola príliš malá, vypíšeme chybové hlásenie
                    Console.WriteLine("Error!!");
                }
            }
        }
        public void LoadingUI()
        {
            // Jednoduchá animácia loadingu: opakovane zobrazí logo a "Loading" v rôznych stavoch
            LogoCSN();
            StredLoga();
            Console.WriteLine("Loading....");
            Thread.Sleep(1000);
            Console.Clear();
            LogoCSN();
            StredLoga();
            Console.WriteLine("Loading.");
            Thread.Sleep(1000);
            Console.Clear();
            LogoCSN();
            StredLoga();
            Console.WriteLine("Loading..");
            Thread.Sleep(1000);
            Console.Clear();
            LogoCSN();
            StredLoga();
            Console.WriteLine("Loading...");
            Thread.Sleep(1000);
            Console.Clear();
            LogoCSN();
            StredLoga();
            Console.WriteLine("Loading....");
            Thread.Sleep(1000);
            Console.Clear();
            LogoCSN();
            StredLoga();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Casino loaded");
            Thread.Sleep(6000);
            Console.ResetColor();

        }
        private void StredLoga()
        {
            // Pomocná metóda na nastavenie kurzora pri logu
            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2;
            int y = centerY + 5;
            int x = Math.Max(0, centerX - 4);
            Console.SetCursorPosition(x, y);
        }
    }
}