using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie_CookieClicker.Upgrades
{
    public abstract class Upgrade
    {
        public virtual string UpgradeName { get; set; }             //Nazov upgradu
        public virtual int CookiesPriceToBuy { get; set; }               //Cena v cookies za upgrade
        public virtual int Multiplier { get; set; }                //Nasobic , udrzuje informaciu o tom kolko uzivatel vlastni dany upgrade       

        public abstract void Apply(Player player);
        public abstract int CalculateCookiesForUpgrade(Player player);
        public abstract string GetUpgradeInfo();
    }
}