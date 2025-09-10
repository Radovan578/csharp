using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*bool isAdult = false;
            Console.WriteLine(isAdult);

            int myAge = 15;
            Console.WriteLine(myAge);

            float pi = 3.14f;
            Console.WriteLine(pi);

            string name = "Rado";
            Console.WriteLine(name);

            char gender = 'M';
            Console.WriteLine(gender);
            */

            int a = 10;
            int b = 20 + 30;

            int sum = a + b;
            //Scitavanie cisla A a B
            Console.WriteLine(sum);
            Console.WriteLine(a + b);
            Console.WriteLine(10 + 5);

            //Odcitavanie cisla A a B
            Console.WriteLine(a - b);

            //Nasobenie cisla A a B
            Console.WriteLine(a * b);

            //Delenie cisla A a B
            Console.WriteLine(a / b);




            int birthDay = 23;
            int birthMonth = 2;
            int birthYear = 2010;

            //Scitanie datumu narodenia a mesiaca a roku do premmennej birthSum
            int birthSum = birthDay + birthMonth + birthYear;


            //Vypisanie na konzolu birthSum
            Console.WriteLine(birthSum);

            //Nasledne vynasobte birthSum * 10 a vypiste nasobok
            Console.WriteLine(birthSum * 10);

            //Scitajte datum narodenia a mesiac a prenasobte rokom
            Console.WriteLine((birthDay + birthMonth) * birthYear);

            //Problem s int a float
            Console.WriteLine(5f / 3f);

            //Vytvorte si premennu s vasim menom a scitajte ju s rokom narodenia
            string name = "Rado";
            Console.WriteLine(name + birthYear);

            //Vypiste meno a sucet dna a mesiaca narodenia
            Console.WriteLine(name + (birthDay + birthMonth));


            bool result = 6 >= 3;
            Console.WriteLine(result);


            int krabickaA = 10;
            int krabickaB = krabickaA;
            krabickaA = 6;
            Console.WriteLine(krabickaA == krabickaB);

        }
    }
}
