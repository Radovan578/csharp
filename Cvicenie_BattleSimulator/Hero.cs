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
        public int HP { get; set; } = 100;    //Health points
        public int DMG { get; set; } = 10;   //Damage
        public int ENG { get; set; } = 100;       //Energy
        public int SHD { get; set; } = 15;         //Shield


        public bool HeroAttack(Monster monster)
        {
            if (ENG - 20 >= 0)
            {
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
        



    }
}
