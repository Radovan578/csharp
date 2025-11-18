using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie_BattleSimulator
{
    public class Hero
    {
        public string Name { get; set; } = "Arnost";  //Hero name
        public int HP { get; set; } = 250;    //Health points
        public int MinDMG { get; set; } = 20;   // Najmensi Damage
        public int MaxDMG { get; set; } = 40;     // Najvacsi Damage
        public int ENG { get; set; } = 100;       //Energy
        public int SHD { get; set; } = 15;         //Shield

        

        public bool HeroAttack(Monster monster)
        {
            List<int> damage = new List<int>();
            damage.Add(MinDMG);
            damage.Add(MaxDMG); 
            Random r = new Random();
            

            if (ENG - 20 >= 0)
            {
                int count = damage.Count;
                int index = r.Next(count);
                int DMG = damage[index];

                ENG = ENG - 20;         //za jeden utok sa odcita 20 energy
                monster.HP = monster.HP - DMG;  //zrani monstrum
                return true;
            }
            else
            {
                ENG = ENG + 50;  //ak nema dost energy, tak si ju trochu obnovi
                return false;
            }
        }
        public bool HeroAttack2(Monster2 monster2)
        {
            List<int> damage = new List<int>();
            damage.Add(MinDMG);
            damage.Add(MaxDMG);
            Random r = new Random();

            if (ENG - 20 >= 0)
            {
                int count = damage.Count;
                int index = r.Next(count);
                int DMG = damage[index];

                ENG = ENG - 20;         //za jeden utok sa odcita 20 energy
                monster2.HP2 = monster2.HP2 - DMG;  //zrani monstrum
                return true;
            }
            else
            {
                ENG = ENG + 50;  //ak nema dost energy, tak si ju trochu obnovi
                return false;
            }
        }




    }
}
