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
            string name = Console.ReadLine();                                           //Registracia
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
                Player MyPlayer = new Player(20, name, age, 0);

                while (true)
                {
                    HodMincou hodMincou = new HodMincou();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(@" __          __  _                            _           _____          _             
\ \        / / | |                          | |         / ____|        (_)            
 \ \  /\  / /__| | ___ ___  _ __ ___   ___  | |_ ___   | |     __ _ ___ _ _ __   ___  
  \ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | |    / _` / __| | '_ \ / _ \ 
   \  /\  /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |___| (_| \__ \ | | | | (_) |
    \/  \/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/   \_____\__,_|___/_|_| |_|\___/ 
                                                                                      
                                                                                      "); Console.ResetColor();
                    Console.WriteLine(" ");
                    Console.WriteLine("Cislom vyber akciu: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("1.Slot Machine");
                    Console.ResetColor();
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("2.Hod Mincou");
                    Console.ResetColor();
                    Console.WriteLine(" ");                                             //Menu
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
                     
                    if (command == 1)                                         //Vyber hier
                    { 

                    }
                    if (command == 2)
                    {
                        Console.Clear();
                        hodMincou.HodMincouGame(MyPlayer);
                    }
                    if (command == 9)
                    {
                        return;
                    }
                    if (command == 67)
                    {
                        MyPlayer.Kredit += 20;
                        Console.WriteLine("RECEPT NA BRAVCOVY GULAS");
                        Console.WriteLine(@"Ingrediencie
1 kg
bravčové mäso (karé, krkovička al. stehno)
4 PL
bravčová masť
4 ks
veľka cibuľa
2 PL
mletá paprika
1 PL
drvená rasca
1 KL
mleté čierne korenie
3 ks
paradajka
3 ks
paprika
6 ks
stredne veľké zemiaky
2 ks
bobkový list
4 strúčiky
cesnak
1 PL
majoránka
podľa chuti
soľ
Postup
1
V hrnci zahrejeme masť a pridáme nadrobno nasekanú cibuľu, ktorú zľahka posolíme a restujeme do sklovita.

2
K mäkkej cibuľke potom pridáme na kocky pokrájané mäso, ktoré ochutíme soľou, čiernym korením, rascou a mletou paprikou. Všetko dobre premiešame a mäso necháme zakryté dusiť vo vlastnej šťave zhruba 10 minút.

3
Medzitým si olúpeme paradajky (narežeme ich do kríža, na 30 sekúnd ich ponoríme do vriacej vody, ochladíme a stiahneme šupku) a nakrájame ich na kocky. Papriky nakrájame na tenučké rezančeky, zemiaky očistíme – 4 nakrájame na kocky a 2 odložíme bokom.

4
Paradajky, papriky a bobkové listy pridáme k mäsu, prilejeme iba toľko vody, aby bolo mäso ponorené, privedieme k varu, zakryjeme a na miernom plameni dusíme cca hodinu.

5
Po hodine postrúhame dva celé zemiaky na jemnom strúhadle a spolu so zemiakovými kockami ich pridáme k mäsu. Prilejeme toľko vody, aby bolo všetko zakryté a dusíme ďalších cca 20 minút.

6
Nakoniec guláš dochutíme soľou, prelisovaným cesnakom, majoránom, ešte krátko (5 minút) povaríme a podávame.

7
Ďalšie overené recepty na gulášové špeciality nájdete TU! ");
                        return;
                    }


                }











            }



        }
    }
}