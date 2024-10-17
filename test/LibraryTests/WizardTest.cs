using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;
using NUnit.Framework;

public class WizardTests
{
    [Test]
    public void TestWizard()
    {
        Staff staff = new Staff();
        SpellOne electricSpell = new SpellOne();
        SpellOne airSpell = new SpellOne();
        SpellsBook spellsBook1 = new SpellsBook();
        SpellsBook spellsBook2 = new SpellsBook();

        spellsBook1.AddSpell(electricSpell);
        spellsBook2.AddSpell(airSpell);

        Wizard wizard1 = new Wizard("Gandalf");
        Wizard wizard2 = new Wizard("Saruman");
        
        wizard1.AddItem(spellsBook1);
        wizard2.AddItem(spellsBook2);
        
        Assert.That(wizard1.Health, Is.EqualTo(100));
        Assert.That(wizard2.Health, Is.EqualTo(100));
    }
}    