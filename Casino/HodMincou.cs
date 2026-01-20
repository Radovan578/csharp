using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Casino
{
    public class HodMincou
    {
        public string Hlava { get; set; } = "Hlava";
        public string Orol { get; set; } = "Orol";


        public void HodMincouGame(Player player)                                       //hrac vybera stavku
        {
            // Min hra "Hod mincou": hráč vsádza na Hlava alebo Orol
            while (true)
            {
                Console.WriteLine("Pre menu stlac 'M', Pre pokracovanie stlac hociaku klavesu ");
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.M)
                {
                    // Návrat do menu
                    Console.Clear();
                    break;
                }
                else
                {
                    // Zistenie stávky od hráča
                    Console.WriteLine("Kolko chces stavit?");
                    string stavkaTxt = Console.ReadLine();
                    int stavka = int.Parse(stavkaTxt);


                    if (stavka > player.Kredit)
                    {
                        // Nedostatok kreditu
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nemas dostatok peňazí na hranie!");
                        Console.ResetColor();
                        return;
                    }
                    else
                    {
                        // Vytvorenie zoznamu možností a náhodný výber výsledku
                        List<string> symbols = new List<string>();                          //nahodne vybratie znaku
                        symbols.Add(Hlava);
                        symbols.Add(Orol);
                        Random r = new Random();
                        int index = r.Next(symbols.Count);
                        string symbol = symbols[index];

                        // Hráč vyberie znak
                        Console.WriteLine("Vyber si znak: 1.Hlava 2.Orol ");
                        string SymbolPick = Console.ReadLine();
                        if (SymbolPick == "1")
                        {
                            // Porovnanie výberu s náhodným výsledkom
                            SymbolPick = Hlava;                                    //porovnanie znakov
                            if (SymbolPick == symbol)
                            {
                                int vyhra = stavka * 2;
                                player.Kredit += vyhra;
                                player.Xp += 2;
                                Console.ForegroundColor = ConsoleColor.Green;

                                Console.WriteLine("Vyhral si!");
                                Console.WriteLine("Dostávaš: " + vyhra + " EUR");
                                Console.ResetColor();

                            }
                            else
                            {
                                // Prehra: odpočítanie stávky a pridanie XP
                                Console.ForegroundColor = ConsoleColor.Red;
                                player.Xp += 1;

                                player.Kredit -= stavka;
                                Console.WriteLine("Prehral si " + stavka + " EUR");
                                Console.ResetColor();

                            }
                        }
                        else if (SymbolPick == "2")
                        {
                            // Rovnaká logika pre druhú možnosť
                            SymbolPick = Orol;
                            if (SymbolPick == symbol)
                            {
                                int vyhra = stavka * 2;
                                player.Kredit += vyhra;
                                player.Xp += 2;

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Vyhral si!");
                                Console.WriteLine("Dostavas: " + vyhra + " EUR");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                player.Xp += 1;

                                player.Kredit -= stavka;
                                Console.WriteLine("Prehral si " + stavka + " EUR");
                                Console.ResetColor();

                            }
                        }
                    }
                }
            }
        }
    }
}