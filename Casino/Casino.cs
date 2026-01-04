using System;
using System.Collections.Generic;
using System.Linq;
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
            LogoCasino logoCSN = new LogoCasino();
            logoCSN.StartUI();
            Thread.Sleep(500);
            Console.Clear();

            Player MyPlayer = SaveGame.Load();
            if (MyPlayer == null)
            {
                Console.WriteLine(@" ====================================
 |        CASINO ADMIRAL LOGIN      |
 ====================================
 |                                  |
 |   Zadaj meno:                    |
 |                                  |
 |   Zadaj vek :                    |
 |                                  |
 |     [   P O K R A Č O V A Ť    ] |
 ====================================");
                Console.SetCursorPosition(18, 4);
                string name = Console.ReadLine();

                Console.SetCursorPosition(18, 6);
                string ageTxt = Console.ReadLine();
                int age = int.Parse(ageTxt);
                Console.Clear();
                Console.WriteLine("LOADING.......");
                Thread.Sleep(500);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vďaka za prihlásenie pusť prosím program ešte raz");


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
                else if (age == 67)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Deleting C:\\Users\\System32..........");
                    Console.ResetColor();
                    return;
                }

                MyPlayer = new Player(10, name, age, 0, 0);
                SaveGame.Save(MyPlayer);
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Vitaj späť, {MyPlayer.Name}!");
                Thread.Sleep(1000);

                while (true)
                {
                    HodMincou hodMincou = new HodMincou();
                    SlotMachine slotMachine = new SlotMachine();
                    Ruleta ruleta = new Ruleta();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(@" __          __  _                            _           _____          _             
 \ \        / / | |                          | |         / ____|        (_)            
  \ \  /\  / /__| | ___ ___  _ __ ___   ___  | |_ ___   | |     __ _ ___ _ _ __   ___  
   \ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | |    / _` / __| | '_ \ / _ \ 
    \  /\  /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |___| (_| \__ \ | | | | (_) |
     \/  \/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/   \_____\__,_|___/_|_| |_|\___/ 
                                                                                       
                                                                                       ");
                    Console.ResetColor();
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("1.Hod Mincou");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("2.Automat");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("3.Ruleta");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("9. Ukončiť hru");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tvoje kredit: " + MyPlayer.Kredit);
                    Console.WriteLine("xp: " + MyPlayer.Xp + "/" + "Level: " + MyPlayer.Level);
                    Console.ResetColor();

                    string commandTxt = Console.ReadLine();
                    int command = int.Parse(commandTxt);

                    switch (command)
                    {
                        case 2:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(@"   _____ _       _     __  __            _     _             
  / ____| |     | |    |  \/  |          | |   (_)            
 | (___ | | ___ | |_   | \  / | __ _  ___| |__  _ _ __   ___  
  \___ \| |/ _ \| __|  | |\/| |/ _` |/ __| '_ \| | '_ \ / _ \ 
  ____) | | (_) | |_   | |  | | (_| | (__| | | | | | | |  __/ 
 |_____/|_|\___/ \__|  |_|  |_|\__,_|\___|_| |_|_|_| |_|\___| 
                                                             
                                                             ");
                            Console.ResetColor();

                            slotMachine.SlotMachineGame(MyPlayer);
                            break;
                        case 1:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(@"  _    _           _   __  __ _                       
 | |  | |         | |  |  \/  (_)                      
 | |__| | ___   __| |  | \  / |_ _ __   ___ ___  _   _ 
 |  __  |/ _ \ / _` |  | |\/| | | '_ \ / __/ _ \| | | |
 | |  | | (_) | (_| |  | |  | | | | | | (_| (_) | |_| |
 |_|  |_|\___/ \__,_|  |_|  |_|_|_| |_|\___\___/ \__,_|
                                                      
                                                      ");
                            Console.ResetColor();
                            hodMincou.HodMincouGame(MyPlayer);
                            break;
                        case 3:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine(@"
 _____            _      _   _       
|  __ \          | |    | | | |      
| |__) |___  _   _| | ___| |_| |_ ___ 
|  _  // _ \| | | | |/ _ \ __| __/ _ \
| | \ \ (_) | |_| | |  __/ |_| ||  __/
|_|  \_\___/ \__,_|_|\___|\__|\__\___|
                                     ");
                            Console.ResetColor();
                            ruleta.RouletteGame(MyPlayer);
                            break;
                        case 9:
                            SaveGame.Save(MyPlayer);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Hra uložená. Dovidenia!");
                            Console.ResetColor();
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Neplatný príkaz, skús znova.");
                            Console.ResetColor();
                            break; 
                    }
                    if (MyPlayer.Xp > 5)
                    {
                        MyPlayer.Xp = 0;
                        MyPlayer.Level += 1;
                    }
                }
            }
        }
    }
}