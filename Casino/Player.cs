using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Player
    {
        public int Kredit { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Level { get; set; }

        public Player(int kredit, string name, int age, int level)
        {
            Kredit = kredit;
            Name = name;
            Age = age;
            Level = level;
        }
    }
}