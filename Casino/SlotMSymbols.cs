using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class SlotMSymbols
    {
        public char Symbol { get; set; }
        public int Chance { get; set; }

        public SlotMSymbols(char symbol, int chance)
        {
            Symbol = symbol;
            Chance = chance;
        }
    }
}