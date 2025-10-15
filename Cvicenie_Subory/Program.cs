using System.Diagnostics.CodeAnalysis;
using static System.Net.Mime.MediaTypeNames;

namespace Cvicenie_Subory
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] text = File.ReadAllLines("People_100.csv");
            /*
            MoneyCountAverage(text);
            */
            /*
            WriteRodneCislo(text);
            */
            /*
            MinMoneyCount(text);
            */
            /*
            List<string> mojZoznam = PeopleUnder05M(text);
            */

            PeopleUnder05M(text);
        }
        /*
        public static List<string> PeopleUnder05M(string[] text)
        {
            //pomocny list(nie pole) kde budeme pridavat osoby => list stringov
            foreach (string line in text.Skip(1))
            {
                //splitnut riadok
                //najst kolko ma na ucte penazi
                //ak ma menej ako 500 000 pridat do listu 

            }
               //vrati ti list
        }
        */


        public static void MoneyCountAverage(string[] text)
        {
            int sum = 0;
            foreach (string line in text.Skip(1))
            {
                //Martin,Urban, 690602/2315,Presov,463102,slobodny
                string[] splits = line.Split(";");
                //prekonvertovanie hodnoty z retazca na cislo
                int accountValue = int.Parse(splits[4]);
                //scitanie int hodnoty so sum-om
                sum += accountValue;

            }
            Console.WriteLine(sum / (text.Count() - 1));



        }

        public static void WriteRodneCislo(string[] text)
        {
            foreach (string line in text.Skip(1))
            {
                string[] splits = line.Split(";");

                string RodneCisla = splits[2];
                Console.WriteLine(RodneCisla);
            }

        }
        public static void MinMoneyCount(string[] text)
        {
            int minValue = 9999999;
            string minValuePerson = "";
            foreach (string line in text.Skip(1))
            {
                string[] splits = line.Split(";");

                int accountValue = int.Parse(splits[4]);

                if (accountValue < minValue)
                {
                    minValue = accountValue;
                    minValuePerson = splits[0] + " " + splits[1];
                }
            }
            Console.WriteLine(minValuePerson);
        }
        public static void PeopleUnder05M(string[] text)
        {

            int minValue = 500000;
            string PeopleUnder = "";
            foreach (string line in text.Skip(1))
            {
                string[] splits = line.Split(";");

                int accountValue = int.Parse(splits[4]);

                if (accountValue < minValue)
                {
                    minValue = accountValue;
                    PeopleUnder = splits[0] + " " + splits[1];
                    Console.WriteLine(PeopleUnder);
                }
            }
            


        }




    }
}
