using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class SlotMachine
    {


        public void SlotMachineGame(Player player)
        {
            // Hlavný cyklus pre minihru slot machine
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
                    // Zadanie stávky
                    Console.WriteLine("Kolko chces stavit?");
                    string vstuptxt = Console.ReadLine();
                    int stavka = int.Parse(vstuptxt);

                    if (stavka > player.Kredit)
                    {
                        // Nedostatok kreditu
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nemas dostatok penazi na hranie!");
                        Console.ResetColor();
                        return;
                    }
                    else
                    {
                        // Príprava symbolov a ich pravdepodobností (chance)
                        List<SlotMSymbols> Symbols = new List<SlotMSymbols>();  // Pridanie symbolov
                        Symbols.Add(new SlotMSymbols('7', 3));
                        Symbols.Add(new SlotMSymbols('§', 7));
                        Symbols.Add(new SlotMSymbols('%', 20));

                        // Vytvorenie "stroja" rozšírením zoznamu podľa šance každého symbolu
                        List<SlotMSymbols> MachineS = new List<SlotMSymbols>();
                        foreach (SlotMSymbols Msymbol in Symbols)
                        {
                            for (int i = 0; i < Msymbol.Chance; i++)
                            {
                                MachineS.Add(Msymbol);
                            }
                        }

                        Random random = new Random();

                        // Náhodný výber troch symbolov
                        SlotMSymbols s1 = MachineS[random.Next(MachineS.Count)];
                        SlotMSymbols s2 = MachineS[random.Next(MachineS.Count)];
                        SlotMSymbols s3 = MachineS[random.Next(MachineS.Count)];

                        Console.WriteLine();
                        Console.WriteLine("=========================");
                        Console.WriteLine("       SLOT MACHINE");
                        Console.WriteLine("=========================");
                        Console.WriteLine();
                        Console.WriteLine("| " + s1.Symbol + " | " + s2.Symbol + " | " + s3.Symbol + " |");
                        Console.WriteLine();

                        // Vyhodnotenie výhry pri troma rovnakými symbolmi
                        if (s1.Symbol == s2.Symbol && s2.Symbol == s3.Symbol)
                        {
                            if (s1.Symbol == '7')
                            {
                                int vyhra = stavka * 10;
                                player.Kredit += vyhra;
                                player.Xp += 5;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("JACKPOT!");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Vyhral si!");
                                Console.WriteLine("Dostavas: " + vyhra + " EUR");
                                Console.ResetColor();
                            }
                            else if (s1.Symbol == '§')
                            {
                                int vyhra = stavka * 5;
                                player.Kredit += vyhra;
                                player.Xp += 3;

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Vyhral si!");
                                Console.WriteLine("Dostavas: " + vyhra + " EUR");
                                Console.ResetColor();
                            }
                            else if (s1.Symbol == '%')
                            {
                                int vyhra = stavka * 2;
                                player.Kredit += vyhra;
                                player.Xp += 2;

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Vyhral si!");
                                Console.WriteLine("Dostavas: " + vyhra + " EUR");
                                Console.ResetColor();
                            }


                        }
                        else
                        {
                            // Ak nie sú tri rovnaké symboly, hráč prehral
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