using System.Threading;

namespace Cvicenie_BattleSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero ourHero = new Hero();
            Monster monster1 = new Monster("Goblin", 150, 50);


            while (true)
            {
                //Hero dostal utok od monstra
                monster1.MonsterAttack(ourHero);
                Console.WriteLine("HERO:HP " + ourHero.HP);

                //Monster dostal utok od hrdinu
                bool wasAttack = ourHero.HeroAttack(monster1);
                if (wasAttack)
                {
                    Console.WriteLine("MONSTER:HP " + monster1.HP);
                }
                else
                {
                    Console.WriteLine("---Not enough energy to attack! Restoring energy...");
                    Console.WriteLine("HERO:energy " + ourHero.ENG);
                }

                if (ourHero.HP <= 0)
                {
                    Console.WriteLine("Hero is dead!");
                    break;
                }

                if (monster1.HP <= 0)
                {
                    Console.WriteLine("Monster is dead!");
                    break;
                }



            }
        }
    }
}

