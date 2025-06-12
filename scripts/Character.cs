using System;
using System.Collections.Generic;
using Godot;

public class Character
{
    public string id;
    private int health;
    private string type;
    private string target;
    private int damage;

    List<Character> targets = new List<Character>();

    public Character(string PType, int PHealth, int PDamage)
    {
        id = Guid.NewGuid().ToString();
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

    public string Id()
    {
        return id;
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

    public (bool isDead, string id) DecrementHealth(int damage)
    {
        health -= damage;

        bool checkIsDead = CheckIsDead();

        return (checkIsDead, Id());
    }

    public void RealizingTarget(Character[] currentTargets)
    {
        for (int i = 0; i < currentTargets.Length; i++)
        {
            bool isFound = false;

            for (int j = 0; j < targets.Count; j++)
            {
                if (targets[j].Id() == currentTargets[i].Id())
                {
                    isFound = true;
                    break;
                }
            }

            if (isFound == false)
            {
                targets.Add(currentTargets[i]);
            }
        }
    }

    public void Move()
    {

    }
}