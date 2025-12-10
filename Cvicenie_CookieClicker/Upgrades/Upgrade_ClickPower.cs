using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie_CookieClicker.Upgrades
{
    internal class Upgrade_ClickPower : Upgrade
    {
        public override string UpgradeName { get; set; } = "Click power";
        public override int CookiesPriceToBuy { get; set; } = 10;
        public override int Multiplier { get; set; } = 0;


        public override void Apply(Player player)
        {
            if (player.Cookies >= CookiesPriceToBuy)
            {
                player.Cookies -= CookiesPriceToBuy;
                Multiplier++;
                CookiesPriceToBuy += 50 * Multiplier;
                Console.WriteLine("Upgrade bol kupeny.");
            }
            else
            {
                Console.WriteLine("Nemate dostatok cookies na tento upgrade.");
            }
        }

        public override int CalculateCookiesForUpgrade(Player player)
        {
            return Multiplier;
        }

        public override string GetUpgradeInfo()
        {
            return $"Upgrade: {UpgradeName}, Cena: {CookiesPriceToBuy} cookies, Zvysenie sily kliknutia o: {Multiplier}";
        }
    }
}