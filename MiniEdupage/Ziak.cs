using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEdupage
{
    public class Ziak
    {
        public string Name { get; set; }
        public int PocetZnamok { get; set; }
        public double PriemernaZnamka { get; set; }
        public List<int> Znamky { get; set; }

        public Ziak()
        {
            Name = string.Empty;
            Znamky = new List<int>();
            PocetZnamok = 0;
            PriemernaZnamka = 0.00;
        }
    }
}
