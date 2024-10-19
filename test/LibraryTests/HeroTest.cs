using NUnit.Framework;
using Library.Chars;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests
{
    [TestFixture]
    public class HeroTest
    {
        private Knight hero;

        [SetUp]
        public void Setup()
        {
            hero = new Knight("Knight");
        }

        [Test]
        public void InitialValues()
        {
            Assert.That(hero.Name, Is.EqualTo("Knight"));
            Assert.That(hero.Health, Is.EqualTo(100));
        }

        [Test]
        public void TakeDamageReducesHealth()
        {
            hero.ReceiveAttack(30);
            Assert.That(hero.Health, Is.EqualTo(100));

            hero.ReceiveAttack(80);
            Assert.That(hero.Health, Is.EqualTo(59));
        }
        
        [Test]
        public void TakeDamage()
        {
            int initialHealth = hero.Health;
            hero.ReceiveAttack(-10);
            Assert.That(hero.Health, Is.EqualTo(initialHealth), "La salud del héroe no debe cambiar al recibir un daño negativo.");
        }

        [Test]
        public void AddVictoryPoints()
        {
           
        }
    }
}