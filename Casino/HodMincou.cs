using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.VisualBasic;

namespace Casino
{
    public class HodMincou
    {
        public string Hlava { get; set; } = "Hlava";
        public string Orol { get; set; } = "Orol";


        public void HodMincouGame(Player player)
        {
            Console.WriteLine("Kolko chces stavit?");                  //Vyber stavky
            string stavkaTxt = Console.ReadLine();
            int stavka = int.Parse(stavkaTxt);
            if (stavka > player.Kredit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nemas dostatok kreditov na hranie!");
                Console.ResetColor();
                return;
            }
            else if (stavka <= player.Kredit)
            {
                List<string> symbols = new List<string>();                          //Nahodne vybratie znaku
                symbols.Add(Hlava);
                symbols.Add(Orol);
                Random r = new Random();
                int index = r.Next(symbols.Count);
                string symbol = symbols[index];

                Console.WriteLine("Vyber si znak: 1.Hlava 2.Orol ");                //Uzivatel si vybera znak
                string SymbolPick = Console.ReadLine();
                if (SymbolPick == "1")
                {
                    SymbolPick = Hlava;

                    if (SymbolPick == symbol)                                            //Porovnavanie znakov, vyhra/prehra
                    {
                        int vyhra = stavka * 2;
                        player.Kredit += vyhra;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Vyhral si!");
                        Console.WriteLine("Dostavas: " + vyhra + "kreditov");
                        Console.ResetColor();
                    }
                    else
                    {
                        player.Kredit -= stavka;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Prehral si. " + stavka);
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
                        Console.WriteLine("Dostavas: " + vyhra + "kreditov");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        player.Kredit -= stavka;
                        Console.WriteLine("Prehral si. " + stavka);
                        Console.ResetColor();
                    }


                }





            }
        }


    }
}