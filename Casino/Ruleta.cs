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
            // Nekonečný herný cyklus
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
                    // Zadanie stávky
                    Console.WriteLine("Kolko chces stavit?");
                    string vstuptxt = Console.ReadLine();
                    int stavka = int.Parse(vstuptxt);

                    if (stavka > player.Kredit)
                    {
                        // Nedostatok kreditu
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nemas dostatok kreditov na hranie!");
                        Console.ResetColor();
                        return;
                    }
                    else
                    {
                        Random random = new Random();

                        // Menu pre ruletu
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

                        // Hráč si vyberá na čo chce staviť
                        int volba = int.Parse(Console.ReadLine());

                        // Stávka na konkrétne číslo
                        int tipCislo = -1;
                        if (volba == 4)
                        {
                            Console.Write("Zadaj číslo (0 - 36 alebo 37 = 00): ");
                            tipCislo = int.Parse(Console.ReadLine());
                        }
                        // Odpočítanie stávky
                        player.Kredit -= stavka;

                        // Vygeneruje náhodné číslo rulety
                        int vysledok = random.Next(0, 38);      // 0–37 (37 = 00)

                        // Zistenie farby
                        string farba = GetFarba(vysledok);

                        Console.WriteLine();
                        Console.WriteLine("Ruleta sa točí...");

                        // Výpis vylosovaného čísla
                        Console.WriteLine($" Padlo číslo: {(vysledok == 37 ? "00" : vysledok.ToString())} ({farba})");       // ak sa padnute cislo rovna 37 vypise sa nula, ak nie tak int sa premeni na string + vypise sa farba

                        // Vyhodnotenie výhry
                        bool vyhra = false;
                        int vyhraSuma = 0;

                        switch (volba)
                        {
                            case 1 when farba == "červená":                   // vyhra za spravnu farbu
                            case 2 when farba == "čierna":
                                player.Xp += 2;
                                vyhra = true;
                                vyhraSuma = stavka * 2;
                                break;

                            case 3 when farba == "zelená":                   // vacsia vyhra za spravnu farbu
                                player.Xp += 10;
                                vyhra = true;
                                vyhraSuma = stavka * 18;
                                break;

                            case 4 when tipCislo == vysledok:                // vyhra za spravne cislo
                                player.Xp += 20;
                                vyhra = true;
                                vyhraSuma = stavka * 36;
                                break;
                        }

                        if (vyhra)
                        {
                            // Pripočítanie výhry ku kreditu a vypísanie výhry
                            player.Kredit += vyhraSuma;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Vyhral si!");
                            Console.WriteLine("Dostavas: " + vyhraSuma + " kreditov");
                            Console.ResetColor();

                        }
                        else
                        {
                            // Vypísanie prehry
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Prehral si " + stavka);
                            Console.ResetColor();
                        }

                    }

                }

                // Farba čísla
                static string GetFarba(int cislo)
                {
                    if (cislo == 0 || cislo == 37)             // cislo 0 a 00 su zelene
                        return "zelená";
                    else if (cislo % 2 == 0)                   // parne cisla su cierne (ak zvysok po deleni cisla 2 je 0, cislo je parne)
                        return "čierna";
                    else                                       // neparne cisla su cervene
                        return "červená";
                }
            }

        }

    }


}