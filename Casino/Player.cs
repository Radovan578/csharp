using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Player
    {
        // Hlavné vlastnosti hráča 
        public int Kredit { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Level { get; set; }
        public int Xp { get; set; }

        public Player(int kredit, string name, int age, int level, int xp)
        {
            Kredit = kredit;
            Name = name;
            Age = age;
            Level = level;
            Xp = xp;
        }
    }
}