using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Casino
{
    public class Work
    {
        public int FirstN { get; set; }
        public int SecondN { get; set; }
        private Random random = new Random();

        public void DoWork(Player player)
        {
            // Min hra: počítanie jednoduchých príkladov za peniaze a XP
            while (true)
            {
                Console.WriteLine("Počítaj ľahké matematické príklady a získavaj za to peniaze.");
                Console.WriteLine("Stlač M pre návrat do menu. Stlač hociakú klávesu pre pracovanie");

                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.M)
                {
                    // Návrat do hlavného menu
                    Console.Clear();
                    break;
                }
                else
                {
                    // Generovanie dvoch náhodných čísel a požiadanie hráča o výsledok
                    FirstN = random.Next(1, 10);
                    SecondN = random.Next(1, 10);
                    Console.WriteLine($"Koľko je {FirstN} + {SecondN} ?");
                    int answer = int.Parse(Console.ReadLine());
                    if (answer == FirstN + SecondN)
                    {
                        // Správna odpoveď: odmena pre hráča
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Správne, získavaš 3 EUR");
                        Console.ResetColor();
                        player.Kredit += 3;
                        player.Xp += 2;
                    }
                    else
                    {
                        // Nesprávna odpoveď: upozornenie
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nesprávna odpoveď. Skús to znova neskôr.");
                        Console.ResetColor();
                    }
                }
            }
        }

    }
}