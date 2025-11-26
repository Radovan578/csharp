using System.ComponentModel;

namespace Cvicenie_Pravdepodobnost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Random rand = new Random();
            int value = rand.Next(0,100);
            Console.WriteLine(value);
            if (value < 80)
            {
                Console.WriteLine("Vyhral ten s 80%");
            }
            else
            {
                Console.WriteLine("Vyhral ten s 20%");
            }
            */
            /*
            Student student1 = new Student("Michal", 5);
            Student student2 = new Student("Matus", 15);
            Student student3 = new Student("Radoslav", 25);
            Student student4 = new Student("Daniel", 55);
            */

            List<Student> Students = new List<Student>();
            Students.Add(new Student("Michal", 5));
            Students.Add(new Student("Matus", 15));
            Students.Add(new Student("Radoslav", 25));
            Students.Add(new Student("Daniel", 55));

            List<Student> klobucik = new List<Student>();
            foreach (Student stud in Students)
            {
                for (int i = 0; i < stud.TicketCount; i++)
                {
                    klobucik.Add(stud);
                }
            }

            Random random = new Random();
            int index = random.Next(klobucik.Count);
            Student vyherca = klobucik[index];
            Console.WriteLine(vyherca.Name + " " + vyherca.TicketCount);
        }
    }
}
