using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie_SIMS
{
    public class Player
    {
        public int Money { get; set; } = 50;
        public int Hunger { get; set; } = 100;
        public int Thirst { get; set; } = 100;
        public int Health { get; set; } = 100;

        public void Working()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Kopes do zeme: " + i);
            }

            Money += 10;
        }
        public void Starving()
        {
            Hunger -= 5;
            if (Hunger <= 0)
            {
                Health -= 10;
            }
;
        }
        public void Thirsting()
        {
            Thirst -= 20;
            if (Thirst <= 0)
            {
                Health -= 10;
            }
        }
        public void Eating()
        {
            Hunger += 20;
            if (Money - 5 >= 0)
            {
                Money -= 5;
            }

        }
        public void Drinking()
        {
            Thirst += 50;
            if (Money - 3 >= 0)
            {
                Money -= 2;
            }
            
        }

    }
}
