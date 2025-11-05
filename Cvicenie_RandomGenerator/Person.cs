using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie_RandomGenerator
{
    public class Person
    {

        public string Name { get; set; }
        public string Surname { get; set; }

        public Person(string nameParam, string surnameParam)
        {
            Name = nameParam;
            Surname = surnameParam;
        }

        public void VypisSa()
        {
            Console.WriteLine("Volam sa: "+Name+" "+Surname);
        }



    }
}
