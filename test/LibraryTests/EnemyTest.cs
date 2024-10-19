using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
using Library.Chars;

namespace Tests
{
    public class EnemyTest
    {
        private Enemy enemy;

        [SetUp]
        public void Setup()
        {
            enemy = new Enemy("Orc", 10);
        }

        [Test]
        public void Enemy_ShouldHaveCorrectName()
        {
            Assert.That(enemy.Name, Is.EqualTo("Orc"), "El nombre del enemigo no es correcto");
        }

        [Test]
        public void Enemy_ShouldReceiveAttack()
        {
            int initialHealth = enemy.Health;
            enemy.ReceiveAttack(20);
            
            Assert.That(enemy.Health, Is.LessThan(initialHealth), "La salud no ha disminuido correctamente tras el ataque");
        }

        [Test]
        public void Enemy_ShouldBeDefeatedAtZeroHealth()
        {
            enemy.ReceiveAttack(enemy.Health + enemy.DefenseValue);
            
            Assert.That(enemy.IsDefeated(), Is.True, "El enemigo no fue derrotado correctamente");
        }

        [Test]
        public void Enemy_ShouldHaveCorrectVictoryPoints()
        {
            Assert.That(enemy.VP, Is.EqualTo(0), "Los puntos de victoria del enemigo no son correctos");
        }
    }
}