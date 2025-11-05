namespace Cvicenie_Objekty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student();
            student1.Name = "Janko Hrasko";
            student1.Age = 15;
            student1.Address = "Bratislava";
            student1.Gender = 'M';

            Student student2 = new Student();
            student2.Name = "Michal Hlavac";
            student2.Age = 20;
            student2.Address = "Cadca";
            student2.Gender = 'Z';

            Student stary = student1;

            string menoStudenta1 = student1.Name;
            menoStudenta1 = "Peter Novak";
            student1.Name = menoStudenta1;
            Console.WriteLine(student1.IsAdult());

            student2.AddName(" Novak");
            Console.WriteLine(student2.Name);
            Console.WriteLine(student2.VypisInfo());
        }
    }
}
