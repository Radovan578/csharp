using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Casino
{
    public class Casino
    {
        private void StredLoga()
        {
            // Nastaví kurzor do stredu spodnej časti obrazovky pre zobrazenie textu
            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2;
            int y = centerY + 5;
            int x = Math.Max(0, centerX - 4);
            Console.SetCursorPosition(x, y);
        }
        public void StartCasino()
        {
            // Hlavná vstupná metóda aplikácie - inicializuje UI, načíta alebo vytvorí hráča a spúšťa menu
            LogoCasino logoCSN = new LogoCasino();
            // logoCSN.StartUI();
            Thread.Sleep(500);
            Console.Clear();

            // Načítanie uloženého hráča (ak existuje)
            Player MyPlayer = SaveGame.Load();
            if (MyPlayer == null)
            {
                // Ak nie je uložená hra, zobrazíme registračný formulár
                Console.WriteLine(@" ====================================
 |      CASINO ADMIRAL REGISTER     |
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

                // Kontrola veku - jednoduché validácie
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

                // Vytvorenie nového hráča s počiatočným kreditom a uloženie
                MyPlayer = new Player(10, name, age, 0, 0);

                SaveGame.Save(MyPlayer);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vďaka za prihlásenie spusť prosím program ešte raz");
            }


            else
            {
                // Ak bol nájdený uložený hráč, privítame ho a otvoríme hlavné menu
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Vitaj späť, {MyPlayer.Name}!");
                Thread.Sleep(1000);
                Console.Clear();


                while (true)
                {
                    // Vytvorenie inštancií pre jednotlivé minihry a akcie
                    HodMincou hodMincou = new HodMincou();
                    SlotMachine slotMachine = new SlotMachine();
                    Ruleta ruleta = new Ruleta();
                    Work work = new Work();



                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(@"   _____          _                           _           _           _ 
  / ____|        (_)                 /\      | |         (_)         | |
 | |     __ _ ___ _ _ __   ___      /  \   __| |_ __ ___  _ _ __ __ _| |
 | |    / _` / __| | '_ \ / _ \    / /\ \ / _` | '_ ` _ \| | '__/ _` | |
 | |___| (_| \__ \ | | | | (_) |  / ____ \ (_| | | | | | | | | | (_| | |
  \_____\__,_|___/_|_| |_|\___/  /_/    \_\__,_|_| |_| |_|_|_|  \__,_|_|
                                                                           ");
                    Console.ResetColor();
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("1. Hod Mincou");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("2. Automat");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("3. Ruleta");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("7. Ísť do práce");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("8. Odstrániť uloženú hru");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("9. Ukončiť hru");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    // Zobrazenie základných informácií o hráčovi
                    Console.WriteLine("Tvoj účet: " + MyPlayer.Kredit + " EUR ");
                    Console.WriteLine("xp: " + MyPlayer.Xp + "/5 " + "|" + " Level: " + MyPlayer.Level);
                    Console.ResetColor();

                    ConsoleKey key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            // Spustenie hry Hod mincou
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
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            // Spustenie automatu
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(@"   _____ _       _     __  __            _     _             
   / ____| |     | |    |  \/  |          | |   (_)            
  | (___ | | ___ | |_   | \  / | __ _  ___| |__  _ _ __   ___  
   \___ \| |/ _ \| __|  | |\/| |/ _` |/ __| '_ \| | '_ \ / _ \ 
   ____) | | (_) | |_   | |  | | (_| | (__| | | | | | | |  __/ 
  |_____/|_|\___/ \__|  |_|  |_|\\__,_|\\___|_| |_|_|_| |_|\\___| 
                                                              ");
                            Console.ResetColor();
                            slotMachine.SlotMachineGame(MyPlayer);
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            // Spustenie rulety
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine(@"
 _____             _      _   _       
|  __ \           | |    | | | |      
| |__) |___  _   _| | ___| |_| |_ ___ 
|  _  // _ \| | | | |/ _ \ __| __/ _ \
| | \ \ (_) | |_| | |  __/ |_| ||  __/
|_|  \_\___/ \__,_|_|\___|\__|\__\___|
                                     ");
                            Console.ResetColor();
                            ruleta.RouletteGame(MyPlayer);
                            break;
                        case ConsoleKey.D7:
                        case ConsoleKey.NumPad7:
                            // Ísť do práce (minihra pre získanie kreditu)
                            Console.Clear();
                            work.DoWork(MyPlayer);

                            break;

                        case ConsoleKey.D8:
                        case ConsoleKey.NumPad8:
                            // Potvrdenie odstránenia uloženého súboru
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Naozaj chceš začať odznova?");
                            Console.WriteLine("Esc pre navrat do menu. Enter pre odstranenie hry");

                            var confirmKey = Console.ReadKey(true).Key;
                            if (confirmKey == ConsoleKey.Enter)
                            {
                                SaveGame.DeleteSave();
                                Console.WriteLine("Uložená hra odstránená. Reštartuj hru.");
                                Console.ResetColor();
                                return;
                            }
                            else if (confirmKey == ConsoleKey.Escape)
                            {
                                Console.WriteLine("Zrušené. Návrat do menu.");
                                Thread.Sleep(1000);
                                Console.Clear();
                                Console.ResetColor();
                            }
                            break;
                        case ConsoleKey.D9:
                        case ConsoleKey.NumPad9:
                            // Uloženie hry a ukončenie programu
                            SaveGame.Save(MyPlayer);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Hra uložená. Dovidenia!");
                            Console.ResetColor();
                            return;
                        default:
                            // Neplatný vstup - upozornenie a návrat do menu
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Neplatný príkaz, skús znova.");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Console.ResetColor();
                            break;
                    }
                    // Automatické zvýšenie levelu, ak hráč získa dostatok xp
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