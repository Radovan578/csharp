using System.Diagnostics.CodeAnalysis;

namespace Cvicenia_Polia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            int[] numbers = new int[7];

            numbers[0] = 10;
            numbers[1] = 15;
            numbers[2] = 35;
            numbers[3] = 48;
            numbers[4] = 2;
            numbers[5] = 1;
            numbers[6] = 19;
            */

            /*
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine("=" + sum);
            */

            /*
            int sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine(sum);
            */

            
            //cyklus pomocou ktoreho naplnime pole cisiel, cez Console.Readline
            Console.WriteLine("Kolko cisiel chcete zadat?:");
            int r = int.Parse(Console.ReadLine());
            int[] numbers = new int[r];
            for (int i = 0; i < r; i++)
            {
                Console.WriteLine("Napis cislo, ktore chces scitat:");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " + ");
                sum += numbers[i];
            }
            Console.Write(" = " + sum);





        }
    }
}
