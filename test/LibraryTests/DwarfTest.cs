namespace LibraryTests;
using Ucu.Poo.RoleplayGame;
using NUnit.Framework;

public class DwarfTests
{
    [Test]
    public void TestDwarf()
    {
        
        Axe salamalecons = new Axe();
        Helmet armor = new Helmet();

        Dwarf brokk = new Dwarf("Brokk");
        brokk.AddItem(salamalecons);
        brokk.AddItem(armor);

        Axe karambit = new Axe();
        Helmet shield = new Helmet();

        Dwarf minidwarf = new Dwarf("Kokemon");
        minidwarf.AddItem(karambit);
        minidwarf.AddItem(shield);
        
        
        brokk.ReceiveAttack(minidwarf.AttackValue);

        
        Assert.That(brokk.Health, Is.EqualTo(86));
    }
}