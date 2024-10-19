using System.Collections.Generic;
using Library.Chars;

namespace Ucu.Poo.RoleplayGame;

public class Knight: IHero
{
    private int health = 100;
    private int victorypoints = 0;
    private List<IItem> items = new List<IItem>();
    public Knight(string name)
    {
        this.Name = name;

        this.AddItem(new Sword());
        this.AddItem(new Armor());
        this.AddItem(new Shield());
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
        if (this.victorypoints >= 5)
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
        int damage = power - this.DefenseValue; 
        if (damage > 0) 
        {
            this.Health -= damage;
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
}
