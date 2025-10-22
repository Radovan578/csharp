using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace Cvicenie_Teploty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var teploty = new List<int> { 3, -1, 12, 7, -3, 0, 19, 14, 2, 5, -5, 8 };
            Console.WriteLine("Napis prikaz:");

            string command = Console.ReadLine();

            if (command == "min")
            {
                int min = teploty.Min();
                Console.WriteLine("Najmensia teplota je:" + min);
            }
            else if (command == "max")
            {
                int max = teploty.Max();
                Console.WriteLine("Najvacsia teplota je:" + max);
            }
            else if (command == "avg")
            {
                double avg = teploty.Average();
                Console.WriteLine("Priemer teplot je: " + avg);
            }
            else if (command == "vypis")
            {
                foreach (int teplota in teploty)
                {
                    Console.Write(teplota + ", ");
                }
               
            }
            else if (command == "nadpriemer")
            {
                int pocetNad = 0;
                foreach (int teplota in teploty)
                {
                    if (teplota > teploty.Average())
                    {
                        pocetNad++;
                    }
                }
                Console.WriteLine("Nad priemerom je " + pocetNad+" cisel");




            }
            else if (command == "help")
            {
                Console.WriteLine("avg - napise priemer");
                Console.WriteLine("min - napise najmensiu teplotu");
                Console.WriteLine("max - napise najvacsiu teplotu");
                Console.WriteLine("vypis - vypise vsetky teploty");
                Console.WriteLine("nadpriemer - napise kolko teplot je nad priemerom");
            }
            else if (command == "del")
            {

            }
        }



    }










    
}
