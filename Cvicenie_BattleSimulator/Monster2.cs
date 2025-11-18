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
        public int MinDMG2 { get; set; } = 13;  //Najmensi Damage
        public int MaxDMG2 { get; set; } = 26;  //Najvacsi Damage
        public Monster2(string raceType2, int hP2)
        {
            RaceType2 = raceType2;
            HP2 = hP2;
        }

        public void Monster2Attack(Hero hero)
        {
            List<int> damage = new List<int>();
            damage.Add(MinDMG2);
            damage.Add(MaxDMG2);
            Random r = new Random();
            int count = damage.Count;
            int index = r.Next(count);
            int DMG2 = damage[index];

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
