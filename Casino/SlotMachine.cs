using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class SlotMachine
    {

        public void SlotMachineGame(Player player)
        {
            while (true)
            {
                Console.WriteLine("Pre menu napis 'm', Pre stavku stlac 'enter' ");
                string command = Console.ReadLine();
                Console.WriteLine("Kolko chces stavit?");
                string vstuptxt = Console.ReadLine();
                int stavka = int.Parse(vstuptxt);
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
                    List<SlotMSymbols> Symbols = new List<SlotMSymbols>();  // Pridanie symbolov
                    Symbols.Add(new SlotMSymbols('7', 3));
                    Symbols.Add(new SlotMSymbols('§', 7));
                    Symbols.Add(new SlotMSymbols('%', 20));

                    List<SlotMSymbols> MachineS = new List<SlotMSymbols>();
                    foreach (SlotMSymbols Msymbol in Symbols)
                    {
                        for (int i = 0; i < Msymbol.Chance; i++)
                        {
                            MachineS.Add(Msymbol);
                        }
                    }

                    Random random = new Random();

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

                    if (s1.Symbol == s2.Symbol && s2.Symbol == s3.Symbol)
                    {
                        if (s1.Symbol == '7')
                        {
                            int vyhra = stavka * 10;
                            player.Kredit += vyhra;

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("JACKPOT!");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Vyhral si!");
                            Console.WriteLine("Dostavas: " + vyhra + " kreditov");
                            Console.ResetColor();
                        }
                        else if (s1.Symbol == '§')
                        {
                            int vyhra = stavka * 5;
                            player.Kredit += vyhra;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Vyhral si!");
                            Console.WriteLine("Dostavas: " + vyhra + " kreditov");
                            Console.ResetColor();
                        }
                        else if (s1.Symbol == '%')
                        {
                            int vyhra = stavka * 2;
                            player.Kredit += vyhra;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Vyhral si!");
                            Console.WriteLine("Dostavas: " + vyhra + " kreditov");
                            Console.ResetColor();
                        }


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