using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Ruleta
    {
        public void RouletteGame(Player player)
        {
            while (true)
            {
                Console.WriteLine("Pre menu napis 'M', Pre stavku stlac 'ENTER' ");
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.M)
                {
                    Console.Clear();
                    break;
                }
                if (key == ConsoleKey.Enter)
                {
                    Console.WriteLine("Kolko chces stavit?");
                    string vstuptxt = Console.ReadLine();
                    int stavka = int.Parse(vstuptxt);

                    if (stavka > player.Kredit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nemas dostatok kreditov na hranie!");
                        Console.ResetColor();
                        return;
                    }
                    else
                    {
                        Random random = new Random();

                        Console.Clear();
                        Console.WriteLine(" RULETA ");
                        Console.WriteLine(" Tvoje Kredit: " + player.Kredit + "  ");
                        Console.WriteLine();
                        Console.WriteLine("Vyber stávku:");
                        Console.WriteLine("1 - Červená");
                        Console.WriteLine("2 - Čierna");
                        Console.WriteLine("3 - Zelená (0 alebo 00)");
                        Console.WriteLine("4 - Konkrétne číslo");
                        Console.Write("Voľba: ");

                        int volba = int.Parse(Console.ReadLine());


                    }

                }


            }


        }
    }
}





