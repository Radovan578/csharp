using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie_CookieClicker.Upgrades
{
    internal class Upgrade_Factory : Upgrade
    {
        public override string UpgradeName { get; set; } = "Cookies factory";
        public override int CookiesPriceToBuy { get; set; } = 20;
        public override int Multiplier { get; set; } = 0;

        public override void Apply(Player player)
        {
            if (player.Cookies >= CookiesPriceToBuy)
            {
                player.Cookies -= CookiesPriceToBuy;
                Multiplier++;
                CookiesPriceToBuy = 5555 * Multiplier;
                Console.WriteLine("Upgrade bol kupeny.");
            }
            else
            {
                Console.WriteLine("Nemate dostatok cookies na tento upgrade.");
            }
        }

        public override int CalculateCookiesForUpgrade(Player player)
        {
            if (player.Day % 10 == 0)
            {
                return Multiplier * 20;        //20 je konstanta
            }
            return 0;
        }

        public override string GetUpgradeInfo()
        {
            return $"Upgrade: {UpgradeName}, Cena: {CookiesPriceToBuy} cookies, Pocet robotnikov: {Multiplier}";
        }
    }
}