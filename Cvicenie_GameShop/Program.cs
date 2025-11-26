using System.Numerics;
using System.Transactions;

namespace Cvicenie_GameShop
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Item> items = LootGenerator.GetRandomLoot();
            Item currentBest = items[0];
            foreach (Item item in items)
            {
                if (item.Price > currentBest.Price)
                {
                    currentBest = item;
                }
            }
            Console.WriteLine(currentBest);

            //New way - LINQ
            Item worst = items.MinBy(item => item.Price);      //najlacnejsi item
            Console.WriteLine(worst);

            Item best = items.MaxBy(item => item.Price);       //najdrahsi item
            Console.WriteLine(best);

            List<Item> orderyByPrice = items.OrderBy(item => item.Price).ToList();
            Console.WriteLine(orderyByPrice[0]);

            List<Item> orderyByPriceNajdrahsi = items.OrderByDescending(item => item.Price).ToList();
            Console.WriteLine("Toto je najdrahsia vec:" + orderyByPriceNajdrahsi[0]);

            List<Item> itemUnder1000 = items.Where(item => item.Price <= 1000).ToList();
            Console.WriteLine("Pocet itemov pod 1000 " + itemUnder1000.Count);

            List<Item> itemBetween500n1000 = items.Where(item => item.Price <= 1000 && item.Price >= 500).ToList();
            Console.WriteLine("Pocet itemov pod 1000 nad 500 " + itemBetween500n1000.Count);
        }
    }
}
