using System.Text.Json;

namespace Cvicenie_Ukladanie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Napis co treba");
            string subor = "osoba.txt";
            string command = Console.ReadLine();
            if (command == "write")
            {
                Osoba osoba1 = new Osoba("Igor", 17);
                Osoba osoba2 = new Osoba("Jano", 27);
                Osoba osoba3 = new Osoba("Peter", 37);
                List<Osoba> ludia = new List<Osoba>();
                ludia.Add(osoba1);
                ludia.Add(osoba2);
                ludia.Add(osoba3);

                string json = JsonSerializer.Serialize(ludia);

                File.WriteAllText(subor, json);

            }
            if (command == "read")
            {
                if (!File.Exists(subor))
                {
                    Console.WriteLine("Subor neexistuje");
                    return;
                }
                string celySuborNacitany = File.ReadAllText(subor);
                List<Osoba> ludia = JsonSerializer.  
                    Deserialize<List<Osoba>>(celySuborNacitany);


                foreach (Osoba o in ludia)
                {
                    Console.WriteLine(o.Meno + " " + o.Vek);
                }


                
            }



            /*
            Osoba osoba2 = new Osoba("Jano", 27);
            Osoba osoba3 = new Osoba("Peter", 37);
            string line = osoba1.UdajeOddeleneCiarkou();
            


            List<string> data = new List<string>();
            string line1 = osoba1.UdajeOddeleneCiarkou();
            data.Add(line1);
            data.Add(osoba2.UdajeOddeleneCiarkou());
            data.Add(osoba3.UdajeOddeleneCiarkou());
            File.WriteAllLines(subor, data);
            */

        }
    }
}
