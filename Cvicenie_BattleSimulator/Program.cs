using System.Threading;

namespace Cvicenie_BattleSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero ourHero = new Hero();
            Monster monster1 = new Monster("Goblin", 150, 20);
            Monster2 monster2 = new Monster2("Troll", 125, 13);
            Monster monster3 = new Monster("Orc", 120, 25);
            List<Monster> monsters = new List<Monster>();
            monsters.Add(monster1);
            monsters.Add(monster3);
            Random r = new Random();

            



            Console.WriteLine("Kto chces aby bojoval s hrdinom? 1. 'Goblin' 2. 'Troll' 3. 'Vsetci' 4. 'Random' ");
            string MonsterName = Console.ReadLine();

            if (MonsterName == "Goblin")
            {
                Console.WriteLine("Utok sa zacal!");
                while (true)
                {
                    //Hero dostal utok od monstra
                    monster1.MonsterAttack(ourHero);
                    Console.WriteLine("HERO:HP " + ourHero.HP);
                    //Monster dostal utok od hrdinu

                    bool wasAttack = ourHero.HeroAttack(monster1);
                    if (wasAttack)
                    {
                        Console.WriteLine(MonsterName + ":HP" + monster1.HP);
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
                        Console.WriteLine(MonsterName + " is dead!");
                        break;
                    }

                }

            }
            if (MonsterName == "Troll")
            {
                Console.WriteLine("Utok sa zacal!");
                while (true)
                {
                    //Hero dostal utok od monstra2
                    monster2.Monster2Attack(ourHero);
                    Console.WriteLine("HERO:HP " + ourHero.HP);

                    //Monster dostal utok od hrdinu
                    bool wasAttack2 = ourHero.HeroAttack2(monster2);
                    if (wasAttack2)
                    {
                        Console.WriteLine(MonsterName + ":HP" + monster2.HP2);
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
                        Console.WriteLine(MonsterName + " is dead!");
                        break;
                    }

                }







            }
            if (MonsterName == "Vsetci")
            {
                Console.WriteLine("Utok sa zacal!");
                while (true)
                {
                    Console.WriteLine("Utok sa zacal!");
                    monster1.MonsterAttack(ourHero);
                    monster2.Monster2Attack(ourHero);
                    monster3.MonsterAttack(ourHero);

                    Console.WriteLine("HERO:HP " + ourHero.HP);

                    bool wasAttack = ourHero.HeroAttack(monster1);
                    if (wasAttack)
                    {
                        Console.WriteLine("BOSS:HP" + monster1.HP);
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
                        Console.WriteLine("Boss is dead!");
                        break;
                    }

                }

            }
            if (MonsterName == "Random") 
            {
                Console.WriteLine("Utok sa zacal!");
                while (true)
                {
                    

                    int pocetPriser = monsters.Count;
                    int ktora = r.Next(0, pocetPriser);
                    monsters[0].MonsterAttack(ourHero);
                    if (ourHero.HP <= 0)
                    {
                        Console.WriteLine("Hero is dead!");
                        break;
                    }
                    ourHero.HeroAttack(monsters[ktora]);
                    if (monsters[ktora].HP <= 0)
                    {
                        monsters.RemoveAt(ktora);
                    }
                    if (monsters.Count == 0)
                    {
                        Console.WriteLine("All monsters are dead.");
                        break;
                    }
                    Console.WriteLine("HERO:HP " + ourHero.HP);

                    foreach (Monster monster in monsters)
                    {
                        Console.WriteLine(monster.RaceType + ":HP" + ourHero.HP);
                    }


                    Console.WriteLine("HERO:HP " + ourHero.HP);

                    bool wasAttack = ourHero.HeroAttack(monster1);
                    if (wasAttack)
                    {
                        Console.WriteLine(  ":HP" + monster1.HP);
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
                        Console.WriteLine("Boss is dead!");
                        break;
                    }


                }








            }





        }
    }
}

