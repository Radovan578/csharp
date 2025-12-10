using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Casino
{
    public class Casino
    {

        public void StartCasino()
        {
            Console.WriteLine("Zadaj svoje Meno");
            string name = Console.ReadLine();
            Console.WriteLine("Vitaj " + name + " zadaj svoj vek");
            string ageTxt = Console.ReadLine();
            int age = int.Parse(ageTxt);
            if (age < 18)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nemáš dostatočný vek na to hrať hazardné hry");
                return;
            }
            else if (age > 100)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Pravdepodobne uz nezijes");
                return;
            }
            else
            {
                while (true)
                {
                    Player MyPlayer = new Player(10, name, age, 0);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(name + @" vitaj v Kasínku Admiral Kysucké Nové Mesto!");
                    Console.ResetColor();
                    Console.WriteLine(" ");
                    Console.WriteLine("Cislom vyber akciu: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("1.Slot Machine");
                    Console.ResetColor();
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("2.Hod Mincou");
                    Console.ResetColor();
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("9. Ukončiť hru");
                    Console.ResetColor();
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tvoj KREDIT: " + MyPlayer.Kredit);
                    Console.ResetColor();

                    string commandTxt = Console.ReadLine();
                    int command = int.Parse(commandTxt);

                    if (command == 1)
                    {

                    }
                    if (command == 2)
                    {

                    }
                    if (command == 9)
                    {
                        break;
                    }

                    return;
                }











            }



        }
    }
}