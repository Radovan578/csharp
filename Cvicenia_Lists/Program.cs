using System.ComponentModel;

namespace Cvicenia_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            List<int> numbers = new List<int>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "ADD")
                {
                    string numberTxt = Console.ReadLine();
                    int number = int.Parse(numberTxt);
                    numbers.Add(number);
                }
                else if (command == "END")
                {
                    break;
                }
                else if (command == "DEL")
                {
                    string numberTxt = Console.ReadLine();
                    int number = int.Parse(numberTxt);
                    numbers.Remove(number);
                }
                else if (command == "LIST")
                {
                    foreach (var num in numbers)
                    {
                        Console.WriteLine(num);
                    }
                }
                else if (command == "HAS")
                {
                    string numberTxt = Console.ReadLine();
                    int number = int.Parse(numberTxt);
                    if (numbers.Contains(number))
                    {
                        Console.WriteLine("ANO");

                    }
                    else
                    {
                        Console.WriteLine("NIE");
                    }


                }
                else if (command == "DELI")
                {
                    string numberTxt = Console.ReadLine();
                    int number = int.Parse(numberTxt);
                    numbers.RemoveAt(0);
                }
                else if (command == "COUNT")
                {
                    int sum = numbers.Sum();
                    Console.WriteLine(sum);
                }
                else if (command == "AVG")
                {
                    double avg = numbers.Average();
                    Console.WriteLine(avg);
                }
                else if (command == "MAX")
                {
                    int max = numbers.Max();
                    Console.WriteLine(max);
                }
                else if (command == "HELP")
                {
                    Console.WriteLine("ADD <cislo> – pridá číslo do zoznamu.");
                    Console.WriteLine("DEL <cislo> – zmaže prvý výskyt čísla; ak tam nie je, vypíše napr. NENAJDENE.");
                    Console.WriteLine("DELI <index> – zmaže prvok na danom indexe (0-based); ak index neexistuje, vypíše napr. ZLY INDEX.");
                    Console.WriteLine("HAS <cislo> – vypíše, či zoznam číslo obsahuje (ANO/NIE).");
                    Console.WriteLine("LIST – vypíše celý zoznam v tvare 1 2 5 6 8 9");
                    Console.WriteLine("END – ukončí program.");
                    Console.WriteLine("COUNT - napise sucet vsetkych cisel");
                    Console.WriteLine("AVG - napise priemer");
                    Console.WriteLine("MAX / MIN - napise najmensie/najvacsie cislo");
                    Console.WriteLine("GET <cislo> - napise cislo na zadanom indexe");
                }
                else if (command == "MIN")
                {
                    int min = numbers.Min();
                    Console.WriteLine(min);
                }
                else if (command == "GET")
                {
                    string numberTxt = Console.ReadLine();
                    int number = int.Parse(numberTxt);
                    if (number >= 0 && number < numbers.Count)
                    {
                        Console.WriteLine(numbers[number]);
                    }
                    else
                    {
                        Console.WriteLine("Tento index neexistuje");
                    }
                }
            }







        }
        


















        
    }
}
