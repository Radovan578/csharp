using System.Security.Cryptography.X509Certificates;

namespace Cvicenie_StringMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            string message = "Hello \nWorld!";
            Console.WriteLine(message);               //vysledok: Hello
                                                      //   World!
            string name = "John";
            string greeting = $"Hello, {name} {5 + 10} !";
            string greetingOld = "Hello, " + "John" + (5 + 10) + "!";
            Console.WriteLine(greeting);
            Console.WriteLine(greetingOld);
            */

            /*
            string name = "John";
            Console.WriteLine(name.ToUpper());
            */

            /*
            string name = "Test123Skuska";
            bool contains = name.Contains("123");
            Console.WriteLine(contains + "w");
            */

            /*
            string name = "John123";
            name = name.Replace("John123", "Jan");
            Console.WriteLine(name);
            */

            /*
            int sum = 500;
            double power = Math.Max(4,8);    
            Console.WriteLine(power);
            */
            Console.WriteLine("Zadaj prve cislo:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Zadaj druhe cislo:");
            int number2 = int.Parse(Console.ReadLine());
            int sum = Scitanie(5,10,4,number,number2);
            Console.WriteLine(sum);
        }
        public static int Scitanie(int a, int b, int c, int d, int f)
        {
            int g = a + b + c + d + f;
            return g;


        }










    }
}

