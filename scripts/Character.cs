using System;
using Godot;

public class Character
{
    private int health;
    private string type;
    private string target;
    private int damage;

    public Character(string PType, int PHealth, int PDamage)
    {
        type = PType;
        health = PHealth;
        damage = PDamage;

        if (PType == "ally")
        {
            target = "hostile";
        }
        else if (PType == "hostile")
        {
            target = "ally";
        }
    }

    public int Health()
    {
        return health;
    }

    public int Damage()
    {
        return damage;
    }

    public string Type()
    {
        return type;
    }

    public string Target()
    {
        return target;
    }

    public void Attack(Character _character)
    {
        _character.DecrementHealth(damage);
    }

    private bool CheckIsDead()
    {
        if (health <= 0)
        {
            return true;
        }

        return false;
    }

    public bool DecrementHealth(int damage)
    {
        health -= damage;

        return CheckIsDead();
    }
}