using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class HodMincou
    {
        public string Hlava { get; set; } = "Hlava";
        public string Orol { get; set; } = "Orol";

        public void HodMincouGame()
        {
            Console.WriteLine("Kolko chces stavit?");
            string stavkaTxt = Console.ReadLine();
            int stavka = int.Parse(stavkaTxt);
            if (stavka < 1)
            {
                Console.WriteLine("Nemas dostatok kreditov na hranie!");
            }
            else if (stavka >= 1)
            {
                Console.WriteLine("Vyber si znak: 1.Hlava 2.Orol ");
                string symbol = Console.ReadLine();

            }
        }


    }
}