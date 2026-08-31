namespace miniKalkulacka
{
    public class Program
    {
        static void Main(string[] args)
        {
            int vysledok = 0;

            Console.WriteLine("Napis prve cislo: ");
            int pCislo = int.Parse(Console.ReadLine());

            Console.WriteLine("Napis druhe cislo: ");
            int dCislo = int.Parse(Console.ReadLine());

            Console.WriteLine("Co s nimi chces spravit? ( +, -, *, / )");
            string znak = Console.ReadLine();

            if (znak == "+")
            {
                vysledok = pCislo + dCislo;
            }
            else if (znak == "-")
            {
                vysledok = pCislo - dCislo;
            }
            else if (znak == "*")
            {
                vysledok = pCislo * dCislo;
            }
            else if (znak == "/")
            {
                vysledok = pCislo / dCislo;
            }

            Console.WriteLine(pCislo + znak + dCislo + " = " + vysledok);
            
        }
    }
}
