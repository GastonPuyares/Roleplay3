namespace LibraryTests;

using Ucu.Poo.RoleplayGame;
using NUnit.Framework;

public class KnightTests
{
    [Test]
    public void TestKnightReceivesAttack()
    {
        
        Sword excalibur = new Sword();
        Armor plateArmor = new Armor();
        Shield ironShield = new Shield();

        Knight arthur = new Knight("Arthur");
        Knight lancelot = new Knight("Lancelot");
        arthur.ReceiveAttack(lancelot.AttackValue);
        
        Assert.That(arthur.Health, Is.LessThan(120)); 
    }

    [Test]
    public void TestKnightCureRestoresHealth()
    {
        
        Knight arthur = new Knight("Arthur");
        arthur.ReceiveAttack(50);

        
        Assert.That(arthur.Health, Is.EqualTo(89)); 
    }

    [Test]
    public void TestKnightAttackValue()
    {
        Knight arthur = new Knight("Arthur");
        int attackValue = arthur.AttackValue;
        Assert.That(attackValue, Is.GreaterThan(0)); 
    }

    [Test]
    public void TestKnightDefenseValue()
    {
        Knight arthur = new Knight("Arthur");
        
        int defenseValue = arthur.DefenseValue;
        
        Assert.That(defenseValue, Is.GreaterThan(0)); 
    }
}