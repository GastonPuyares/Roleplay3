using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace LibraryTests;

public class ArcherTests
{
    [Test]
    public void TestArcher()
    {
        Bow bow = new Bow();
        Helmet helmet = new Helmet();

        Archer arqueromagico = new Archer("Arquero Mágico");
            arqueromagico.AddItem(bow);
            arqueromagico.AddItem(helmet);

            Archer megaarquero = new Archer("Mega Arquero");
            
            megaarquero.ReceiveAttack(arqueromagico.AttackValue);

            Assert.That(megaarquero.Health, Is.EqualTo(88));
    }
}