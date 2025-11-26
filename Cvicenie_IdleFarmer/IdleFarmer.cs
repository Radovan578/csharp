using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Cvicenie_IdleFarmer
{
    public class IdleFarmer
    {
        public Random RandomGenerator { get; set; } = new Random();
        public int Money { get; set; } = 15;
        public int Day { get; set; }
        public List<Plant> Field { get; set; } = new List<Plant>();
        public List<Plant> Storage { get; set; } = new List<Plant>();
        public int PriceOfPlant { get; set; } = 5;

        public void StartGame()
        {
          
            Plant cibula = new Plant("Cibula", 5, 10);
            Plant pomaranc = new Plant("Pomaranc", 40, 8);
            Plant jahoda = new Plant("Jahoda", 20, 5);

            Field.Add(cibula);
            Field.Add(pomaranc);
            Field.Add(jahoda);

           
            

            while (true)
            {
                //Koniec dna
                Day++;
                
                //Na konci dna vyrastie rastlinka o jeden "bod"
                foreach (Plant plant in Field)
                {
                    plant.TimeInGround++;
                }

                //Vypis stavu rastliniek na poli
                foreach (Plant plant in Field)
                {
                    Console.WriteLine(plant);
                }

                //Kontrola ci rastlina nevyrastla a neni ready na zber, ak je tak si ju zapis do "notesa"
                List<Plant> harvestedPlants = new List<Plant>();
                foreach (Plant plant in Field)
                {
                    if (plant.TimeInGround >= plant.TimeForHarvest)
                    {
                        Console.WriteLine("Rastlinka nam vyrastla" + plant);
                        harvestedPlants.Add(plant);
                    }
                }

                //Zber rastlieniek z "notesu" a uskladnenie
                foreach (Plant plant in harvestedPlants)
                {
                    Field.Remove(plant);
                    Storage.Add(plant);
                }

                Console.WriteLine("Koniec dna" + Day);

                Console.WriteLine("Penazenka:" + Money);
                Console.WriteLine("Menu:");
                Console.WriteLine("Enter Novy den");
                Console.WriteLine("1 Pridanie rastlinky");
                Console.WriteLine("2 Ukaz sklad");
                Console.WriteLine("3 Predat sklad");


                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        if (Money < PriceOfPlant)
                        {
                            Console.WriteLine("Nemas peniaze na rastliny");
                            break;
                        }
                        else
                        {

                            int dobaRastu = RandomGenerator.Next(10, 30);
                            int finalPrice = RandomGenerator.Next(5, 15);
                            Plant newPlant = new Plant("Zelenina", dobaRastu, finalPrice);
                            Money = Money - finalPrice;
                            Field.Add(newPlant);
                            break;
                        }
                        
                    case "2":
                        foreach (Plant plant in Storage)
                        {   
                            Console.WriteLine(plant);
                        }
                        Console.ReadLine();
                        break;
                    case "3":
                        int sum = 0;
                        foreach (Plant plant in Storage)
                        {
                            sum += plant.Price;
                        }
                        Money += sum * Storage.Count;
                        Storage.Clear();
                        break;

                    default:
                        break;



                }

                Console.Clear();





            }



        }



    }
}
