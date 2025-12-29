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
            while (true)
            {

                Console.WriteLine("Pre menu napis 'm', Pre stavku stlac 'enter' ");
                string command = Console.ReadLine();
                Console.WriteLine("Kolko chces stavit?");
                string stavkaTxt = Console.ReadLine();
                int stavka = int.Parse(stavkaTxt);
                if (command == "m")
                {
                    break;
                }
                if (stavka > player.Kredit)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nemas dostatok kreditov na hranie!");
                    Console.ResetColor();
                    return;
                }
                else
                {
                    List<string> symbols = new List<string>();                          //nahodne vybratie znaku
                    symbols.Add(Hlava);
                    symbols.Add(Orol);
                    Random r = new Random();
                    int index = r.Next(symbols.Count);
                    string symbol = symbols[index];

                    Console.WriteLine("Vyber si znak: 1.Hlava 2.Orol ");
                    string SymbolPick = Console.ReadLine();
                    if (SymbolPick == "1")
                    {
                        SymbolPick = Hlava;                                    //porovnanie znakov
                        if (SymbolPick == symbol)
                        {
                            int vyhra = stavka * 2;
                            player.Kredit += vyhra;
                            Console.ForegroundColor = ConsoleColor.Green;

                            Console.WriteLine("Vyhral si!");
                            Console.WriteLine("Dostavas: " + vyhra + " kreditov");
                            Console.ResetColor();

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            player.Kredit -= stavka;
                            Console.WriteLine("Prehral si " + stavka);
                            Console.ResetColor();

                        }
                    }
                    else if (SymbolPick == "2")
                    {
                        SymbolPick = Orol;
                        if (SymbolPick == symbol)
                        {
                            int vyhra = stavka * 2;
                            player.Kredit += vyhra;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Vyhral si!");
                            Console.WriteLine("Dostavas: " + vyhra + " kreditov");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            player.Kredit -= stavka;
                            Console.WriteLine("Prehral si " + stavka);
                            Console.ResetColor();

                        }


                    }




                }
            }
            
        }
    }
}