using System;
using System.Collections.Generic;
using Godot;

public partial class Character : StaticBody2D
{
    public string id;
    private int health;
    private string type;
    private string target;
    private int damage;

    private List<Character> targets = new List<Character>();

    public Character()
    {
        id = Guid.NewGuid().ToString();
    }

    public int Health()
    {
        return health;
    }

    public string Id()
    {
        return id;
    }

    public List<Character> Targets()
    {
        return targets;
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
        if (targets.Count > 0)
        {
            Character nearestTarget = targets[0];
            for (int i = 0; i < targets.Count; i++)
            {
                float x_point = targets[i].Position.X;
                float y_point = targets[i].Position.Y;
            }
        }

    }
}