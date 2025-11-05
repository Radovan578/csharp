using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie_BattleSimulator
{
    public class Monster2
    {
        public string RaceType2 { get; set; }   //Monster race type (e.g., Goblin, Orc, Troll)
        public int HP2 { get; set; }    //Health points
        public int DMG2 { get; set; }    //Damage

        public Monster2(string raceType2, int hP2, int dMG2)
        {
            RaceType2 = raceType2;
            HP2 = hP2;
            DMG2 = dMG2;
        }

        public void Monster2Attack(Hero hero)
        {

            if (hero.SHD > DMG2)
            {
                hero.HP = hero.HP - 0;

            }
            else if (hero.SHD < DMG2)
            {
                hero.HP = (hero.SHD + hero.HP) - DMG2;

            }
            DMG2++;
        }




    }
}
