using System;
using System.Collections.Generic;
using Ucu.Poo.RoleplayGame;
using Library.Chars;

namespace Library
{
    public class Encounter
    {
        public List<IHero> heroes;
        public List<Enemy> enemies;

        public Encounter(List<IHero> heroes, List<Enemy> enemies)
        {
                this.heroes = heroes;
                this.enemies = enemies;
        }


        public void DoEncounter()
        {
            while (heroes.Count > 0 && enemies.Count > 0)
            {
                EnemiesAttack();
                
                if (heroes.Count == 0)
                {
                    Console.WriteLine("Todos los héroes han muerto. Los enemigos ganan.");
                    return;
                }
                
                HeroesAttack();
                
                if (enemies.Count == 0)
                {
                    Console.WriteLine("Todos los enemigos han muerto. Los héroes ganan.");
                    return;
                }
            }
        }

        private void EnemiesAttack()
        {
            int numHeroes = heroes.Count;
            for (int i = 0; i < enemies.Count; i++)
            {
                IHero targetHero = heroes[i % numHeroes];
                Console.WriteLine($"{enemies[i].Name} ataca a {targetHero.Name}");
                targetHero.ReceiveAttack(enemies[i].AttackValue);

                if (targetHero.Health == 0)
                {
                    Console.WriteLine($"{targetHero.Name} ha sido derrotado.");
                    heroes.Remove(targetHero);
                }
                if (heroes.Count == 0)
                {
                    break;
                }
            }
        }

        private void HeroesAttack()
        {
            foreach (IHero hero in heroes)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    Console.WriteLine($"{hero.Name} ataca a {enemies[i].Name}");
                    enemies[i].ReceiveAttack(hero.AttackValue);

                    if (enemies[i].Health == 0)
                    {
                        Console.WriteLine($"{enemies[i].Name} ha sido derrotado por {hero.Name}");
                        hero.AddVictoryPoints(enemies[i].VP);
                        enemies.RemoveAt(i); 
                        i--;

                       
                        if (hero.VictoryPoints >= 5)
                        {
                            hero.Cure();
                            Console.WriteLine($"{hero.Name} se ha curado.");
                        }
                    }

                    
                    if (enemies.Count == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
