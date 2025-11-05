using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie_BattleSimulator
{
    public class Monster 
    {
        public string RaceType { get; set; }   //Monster race type (e.g., Goblin, Orc, Troll)
        public int HP { get; set; }    //Health points
        public int DMG { get; set; }    //Damage

        public Monster(string raceType, int hP, int dMG)
        {
            RaceType = raceType;
            HP = hP;
            DMG = dMG;
        }

        public void MonsterAttack(Hero hero)
        {   if (hero.SHD > DMG)
            {
                hero.HP = hero.HP - 0;
            }
            else if (hero.SHD < DMG)
            {
                hero.HP = (hero.SHD + hero.HP) - DMG;
            }



        }
    }
}
