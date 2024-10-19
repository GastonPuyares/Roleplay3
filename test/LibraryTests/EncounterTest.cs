using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
using Library.Chars;
using System.Collections.Generic;
using Library;

namespace LibraryTests
{
    [TestFixture]
    public class EncounterTests
    {
        private Knight hero1;
        private Knight hero2;
        private Enemy enemy1;
        private Enemy enemy2;
        private Encounter encounter;

        [SetUp]
        public void Setup()
        {
        
            hero1 = new Knight("HeroKnight1");
            hero2 = new Knight("HeroKnight2");
            enemy1 = new Enemy("EnemyOrc1", 3); 
            enemy2 = new Enemy("EnemyOrc2", 2);
            encounter = new Encounter(new List<IHero> { hero1, hero2 }, new List<Enemy> { enemy1, enemy2 });
        }

        [Test]
        public void EncounterInitializationTest()
        {
           
            Assert.That(encounter.heroes.Count, Is.EqualTo(2), "El número de héroes no es el esperado.");
            
            Assert.That(encounter.enemies.Count, Is.EqualTo(2), "El número de enemigos no es el esperado.");
        }

        [Test]
        public void EnemiesAttackHeroesTest()
        {
            encounter.DoEncounter();
            
            Assert.That(hero1.Health, Is.LessThan(110), "El héroe 1 no ha recibido el ataque esperado.");
            
            Assert.That(hero2.Health, Is.LessThan(110), "El héroe 2 no ha recibido el ataque esperado.");
        }

        [Test]
        public void HeroesAttackEnemiesTest()
        {
            encounter.DoEncounter();
            
            Assert.That(enemy1.Health, Is.LessThan(100), "El enemigo 1 no ha recibido el ataque esperado.");
            
            Assert.That(enemy2.Health, Is.LessThan(100), "El enemigo 2 no ha recibido el ataque esperado.");
        }

        [Test]
        public void CharacterDeathTest()
        {
            enemy1.ReceiveAttack(150);
            encounter.DoEncounter();
            
            Assert.That(encounter.enemies.Count, Is.EqualTo(0), "El enemigo no fue eliminado tras su muerte.");
        }

        [Test]
        public void HeroGainsVictoryPointsTest()
        {
            enemy1.ReceiveAttack(150);
            encounter.DoEncounter();
            
            Assert.That(hero1.VictoryPoints, Is.EqualTo(5), "El héroe no ha ganado los puntos de victoria correctos.");
        }

        [Test]
        public void HeroCuresAfterFiveVPTest()
        {
            enemy1.ReceiveAttack(150);
            enemy2.ReceiveAttack(150);
            encounter.DoEncounter();
            
            Assert.That(hero1.Health, Is.EqualTo(100), "El héroe no se curó tras ganar 5 o más puntos de victoria.");
        }
    }
}
