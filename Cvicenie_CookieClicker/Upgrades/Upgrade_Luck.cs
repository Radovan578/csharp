﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie_CookieClicker.Upgrades
{
    public class Upgrade_Luck : Upgrade
    {
        public override string UpgradeName { get; set; } = "Luck";
        public override int CookiesPriceToBuy { get; set; } = 10;
        public override int Multiplier { get; set; } = 1;

        public List<Char> LockedKeys { get; set; } = new List<Char>() { 'w', 'e', 'r', 't', 'z', 'u', 'i', 'o', 'p' };
        public List<Char> UnlockedKeys { get; set; } = new List<Char>() { 'q' };



        public override void Apply(Player player)
        {
            if (LockedKeys.Count == 0)
            {
                Console.WriteLine("Vsetky klavesy su uz odomknute.");
                return;
            }

            if (player.Cookies >= CookiesPriceToBuy)
            {
                player.Cookies -= CookiesPriceToBuy;
                Multiplier++;
                CookiesPriceToBuy += (int)Math.Pow(50, Multiplier);

                var unlockedChar = LockedKeys.FirstOrDefault();
                LockedKeys.RemoveAt(0);
                UnlockedKeys.Add(unlockedChar);

                Console.WriteLine("Upgrade bol kupeny.");
            }
            else
            {
                Console.WriteLine("Nemate dostatok cookies na tento upgrade.");
            }
        }

        public override int CalculateCookiesForUpgrade(Player player)
        {
            var rand = new Random();
            var indexToUnlock = rand.Next(UnlockedKeys.Count);
            var luckyChar = UnlockedKeys[indexToUnlock];

            if (player.PressedKey.Key == ConsoleKey.Enter || char.IsAsciiDigit(player.PressedKey.KeyChar))
            {
                return 0;
            }

            if (player.PressedKey.KeyChar == luckyChar && char.IsAsciiLetter(player.PressedKey.KeyChar))
            {
                var cookies = (int)Math.Pow(5, UnlockedKeys.Count);
                Console.WriteLine("Dostal si stastie v podobe" + cookies);
                return cookies;
            }
            else
            {
                var endlessLoop = true;
                while (endlessLoop)
                {

                    var randomNumberA = rand.Next(0, 20);
                    var randomNumberB = rand.Next(0, 30);
                    Console.WriteLine($"Kolko je {randomNumberA}+{randomNumberB}");
                    var answer = Int32.Parse(Console.ReadLine());
                    if (answer == randomNumberA + randomNumberB)
                    {
                        endlessLoop = false;
                        Console.WriteLine("Spravna odpoved! Pokracujeme...");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("Nespravna odpoved! Skus to znova.");
                        Thread.Sleep(1000);
                    }
                }


                var losedCookies = player.Cookies / 2;
                Console.WriteLine("Stratil si " + losedCookies + " pre pokracovanie stlacte lubovolne tlacitko. Trebalo stalcit " + luckyChar);
                Thread.Sleep(1000);
                return -losedCookies;
            }

        }

        public override string GetUpgradeInfo()
        {
            return $"Upgrade: {UpgradeName}, Cena: {CookiesPriceToBuy} cookies, Zvysenie sily kliknutia o: {Multiplier}, Odomknute znaky: {string.Join(' ', UnlockedKeys)}";
        }
    }
}