using System.Threading;

namespace Cvicenie_BattleSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero ourHero = new Hero();
            Monster monster1 = new Monster("Goblin", 150, 20);
            Monster2 monster2 = new Monster2 ("Troll", 125, 13);

            Console.WriteLine("Kto chces aby bojoval s hrdinom? 1. 'Goblin' 2. 'Troll' ");
            string MonsterName = Console.ReadLine();

            if (MonsterName == "Goblin")
            {
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
            if (MonsterName == "Troll")
            {
                while (true)
                {
                    //Hero dostal utok od monstra2
                    monster2.Monster2Attack(ourHero);
                    Console.WriteLine("HERO:HP " + ourHero.HP);

                    //Monster dostal utok od hrdinu
                    bool wasAttack2 = ourHero.HeroAttack2(monster2);
                    if (wasAttack2)
                    {
                        Console.WriteLine("MONSTER:HP " + monster2.HP2);
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

                    if (monster2.HP2 <= 0)
                    {
                        Console.WriteLine("Monster is dead!");
                        break;
                    }

                }
               






            }
            
        }
    }
}

