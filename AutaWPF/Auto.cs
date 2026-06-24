using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutaWPF
{
    public class Auto
    {
        public string SPZ { get; set; }
        public int StartKM { get; set; }
        public double CenaZaKM { get; set; }
        public int EndKM { get; set; }
        public double Cena { get; set; }
        public int NajazdeneKM { get; set; }

        public Auto(string sPZ, int startKM, double cenaZaKM, int endKM, double cena, int najazdeneKM)
        {
            SPZ = sPZ;
            StartKM = startKM;
            CenaZaKM = cenaZaKM;
            EndKM = endKM;
            Cena = cena;
            NajazdeneKM = najazdeneKM;
        }
        public override string? ToString()
        {
            return SPZ + " (" + CenaZaKM + " e/km)";
        }
    }
}
