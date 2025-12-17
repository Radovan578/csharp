using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class SlotMachine
    {
        public char Sign1 { get; set; }
        public char Sign2 { get; set; }
        public char Sign3 { get; set; }
        public Random RandomGenerator { get; set; }

        public SlotMachine(char sign1, char sign2, char sign3)
        {
            this.Sign1 = sign1;
            this.Sign2 = sign2;
            this.Sign3 = sign3;
        }

        public void SlotMachineGame(Player player)
        {

        }


    }
}