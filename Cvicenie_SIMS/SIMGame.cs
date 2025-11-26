using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie_SIMS
{
    public class SIMGame
    {
        public Player MyPlayer { get; set; } = new Player();
        public void StartGame()
        {
            bool isRunning = true;
            /*
            while (isRunning)
            {
                MyPlayer.Starving();
                if (MyPlayer.Health <= 0)
                {
                    Console.WriteLine("Game is over");
                    isRunning = false;
                }
                Console.WriteLine(MyPlayer.Hunger + " " + MyPlayer.Health);
            }
            while (isRunning)
            {
                 MyPlayer.Starving();
                if (MyPlayer.Health <= 0)
                {
                    Console.WriteLine("Game is over");
                    isRunning = false;
                }
                Console.WriteLine(MyPlayer.Hunger + " " + MyPlayer.Health);
            }
            */

            while (isRunning)
            {

                MyPlayer.Starving();
                if (MyPlayer.Health <= 0)
                {
                    Console.WriteLine("Game is over");


                    break;
                }

                MyPlayer.Thirsting();
                if (MyPlayer.Health <= 0)
                {
                    Console.WriteLine("Game is over");
                    break;
                }

                Console.WriteLine("Tvoje zivoty: " + MyPlayer.Health);
                Console.WriteLine("Tvoj hlad: " + MyPlayer.Hunger);
                Console.WriteLine("Tvoj smad: " + MyPlayer.Thirst);
                Console.WriteLine("Menu: ");
                Console.WriteLine("Penazenka:" + MyPlayer.Money);
                Console.WriteLine("1. Chcem pracovat");
                Console.WriteLine("2. Chcem sa najest");
                Console.WriteLine("3. Chcem sa napit");

                string txt = Console.ReadLine();

              
                if (txt == "1")
                {
                    MyPlayer.Working();
                }
                if (txt == "2")
                {
                    MyPlayer.Eating();
                }
                if (txt == "3")
                {
                    MyPlayer.Drinking();
                }
               

            }

        }
    }
}
