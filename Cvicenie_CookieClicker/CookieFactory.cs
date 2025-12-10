using Cvicenie_CookieClicker.Upgrades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie_CookieClicker
{
    internal class CookiesFactory
    {
        public Player Player { get; set; }
        public List<Upgrade> Upgrades { get; set; } = new List<Upgrade>();

        public CookiesFactory()
        {
            Player = new Player();

            var clickPowerUpgrade = new Upgrade_ClickPower();
            var workerUpgrade = new Upgrade_Worker();
            var factoryUpgrade = new Upgrade_Factory();
            var luckUpgrade = new Upgrade_Luck();

            Upgrades.Add(clickPowerUpgrade);
            Upgrades.Add(workerUpgrade);
            Upgrades.Add(factoryUpgrade);
            Upgrades.Add(luckUpgrade);
        }

        public void StartGame()
        {
            while (true)
            {
                GetMenu();

                var key = Console.ReadKey();
                Player.PressedKey = key;
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.NumPad0:
                        Upgrades[0].Apply(Player);
                        WaitAfterBuy();
                        break;
                    case ConsoleKey.NumPad1:
                        Upgrades[1].Apply(Player);
                        WaitAfterBuy();
                        break;
                    case ConsoleKey.NumPad2:
                        Upgrades[2].Apply(Player);
                        WaitAfterBuy();
                        break;
                    case ConsoleKey.NumPad3:
                        Upgrades[3].Apply(Player);
                        WaitAfterBuy();
                        break;
                }

                foreach (var upgrade in Upgrades)
                {
                    Player.Cookies += upgrade.CalculateCookiesForUpgrade(Player);
                }


                Console.Clear();

                Player.Day++;
            }
        }



        public void GetMenu()
        {
            Console.WriteLine("Hrac ma na ucte: " + Player.Cookies);
            Console.WriteLine("0. " + Upgrades[0].GetUpgradeInfo());
            Console.WriteLine("1. " + Upgrades[1].GetUpgradeInfo());
            Console.WriteLine("2. " + Upgrades[2].GetUpgradeInfo());
            Console.WriteLine("3. " + Upgrades[3].GetUpgradeInfo());
        }


        public void WaitAfterBuy()
        {
            Console.ReadKey();
        }
    }
}