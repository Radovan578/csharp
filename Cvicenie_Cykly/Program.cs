using Microsoft.VisualBasic;

namespace Cvicenie_Cykly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("1");
            Console.WriteLine("2");
            Console.WriteLine("3");
            Console.WriteLine("4");
            Console.WriteLine("5");
            Console.WriteLine("6");
            Console.WriteLine("7");
            Console.WriteLine("8");
            Console.WriteLine("9");
            Console.WriteLine("10");
            */


            //Vypiste na konzolu cisla od 0 do 50

            /*for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine(50 + i);
            }*/

            /*
            //Vypiste na konzolu cisla od 100 do 0
            for (int i = 100; i >= 0; i--)
            {
                Console.WriteLine(i);
            }*/

            //Vypiste na konzolu cisla od 1 do 100
            /*
            int i = 0;
            while (i <= 100)
            {
                Console.WriteLine(i);
                i++;
            }*/

            //Pomocou nekonecneho cyklu, porovnajte ci uzivatel zadal
            //slovo "exit" na ukoncenie programu
            //slovo "pozdrav na vyoisanie "Ahoj"
            //ine slova sa ignoruju a kod pokracuje zistovanim slova

            /*
            while (true)
            {
           
                string input = Console.ReadLine();
                if (input == "pozdrav")
                {
                    Console.WriteLine("Ahoj");
                }
                else if (input == "exit" || input == "koniec")
                {
                    break;

                }


            }*/

            /*
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Zadajte exit pre ukoncenie:");
                    string input = Console.ReadLine();
                    if (input == "exit")
                    {
                        break;
                    }
                    Console.WriteLine("Michal");
                }

                Console.WriteLine("Zadajte koniec pre ukoncenie:");
                string inputDva = Console.ReadLine();
                if (inputDva == "koniec")
                {
                    break;
                }

                Console.WriteLine("Igor");
            }*/

            /*
            Console.WriteLine("*");
            Console.WriteLine("**");
            Console.WriteLine("***");
            Console.WriteLine("****");
            Console.WriteLine("*****");
            Console.WriteLine("******");
            Console.WriteLine("*******");
            */
            /*
            for (int i = 1; i <= 7; i++)
            {
                string row = "";
                for (int j = 1; j <= i; j++)
                {
                    row += "*";
                    //row = row + "*"
                }
                Console.WriteLine(row);
            }*/


            Console.WriteLine("Kolko riadkov?:");
            string riadokText = Console.ReadLine();
            int riadok = int.Parse(riadokText);

            Console.WriteLine("Z akeho znaku sa ma robit trojuholnik?:");
            string sign = Console.ReadLine();

            for (int i = 1; i <= riadok; i++)
            {
                string row = "";
                for (int j = 1; j <= i; j++)
                {
                    row += sign;

                }
                Console.WriteLine(row);





            }
        }
    }
}

