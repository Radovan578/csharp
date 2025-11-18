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
        public int HP { get; set; }            //Health points
        public int MinDMG { get; set; } = 15;       //Najmensi Damage
        public int MaxDMG { get; set; } = 35;       // Najvacsi Damage


        public Monster(string raceType, int hP)
        {
            RaceType = raceType;
            HP = hP;
        }

        public void MonsterAttack(Hero hero)
        {
            List<int> damage = new List<int>();
            damage.Add(MinDMG);
            damage.Add(MaxDMG);
            Random r = new Random();
            int count = damage.Count;
            int index = r.Next(count);
            int DMG = damage[index];

            if (hero.SHD > DMG)
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
