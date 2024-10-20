using System.Collections.Generic;
using Library.Chars;

namespace Ucu.Poo.RoleplayGame;

public class Wizard: IMagicCharacter, IHero
{
    private int health = 100;
    private int victorypoints = 0;
    private List<IItem> items = new List<IItem>();
    private List<IMagicalItem> magicalItems = new List<IMagicalItem>();

    public Wizard(string name)
    {
        this.Name = name;

        this.AddItem(new Staff());
    }

    public string Name { get; set; }

    public int VictoryPoints
    {
        get
        {
            return this.victorypoints;
        }
    }
    
    public void AddVictoryPoints(int vp)
    {
        this.victorypoints += vp;
        if (this.VictoryPoints >= 5)
        {
            this.Cure();
        }
    }
    
    
    public int AttackValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.items)
            {
                if (item is IAttackItem)
                {
                    value += (item as IAttackItem).AttackValue;
                }
            }
            foreach (IMagicalItem item in this.magicalItems)
            {
                if (item is IMagicalAttackItem)
                {
                    value += (item as IMagicalAttackItem).AttackValue;
                }
            }
            return value;
        }
    }

    public int DefenseValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.items)
            {
                if (item is IDefenseItem)
                {
                    value += (item as IDefenseItem).DefenseValue;
                }
            }
            foreach (IMagicalItem item in this.magicalItems)
            {
                if (item is IMagicalDefenseItem)
                {
                    value += (item as IMagicalDefenseItem).DefenseValue;
                }
            }
            return value;
        }
    }

    public int Health
    {
        get
        {
            return this.health;
        }
        private set
        {
            if (value < 0)
            {
                this.health = 0;
            }
            else
            {
                this.health = value;
            }
        }
    }

    public void ReceiveAttack(int power)
    {
        if (this.DefenseValue < power)
        {
            this.Health -= power - this.DefenseValue;
        }
    }

    public void Cure()
    {
        this.Health = 100;
    }

    public void AddItem(IItem item)
    {
        this.items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        this.items.Remove(item);
    }

    public void AddItem(IMagicalItem item)
    {
        this.magicalItems.Add(item);
    }

    public void RemoveItem(IMagicalItem item)
    {
        this.magicalItems.Remove(item);
    }

}
