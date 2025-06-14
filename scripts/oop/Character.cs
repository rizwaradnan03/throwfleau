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

    private Character nearestTarget;

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

    public void RealizingTarget(List<Character> currentTargets)
    {
        targets = currentTargets;
    }

    public void FindNearestTarget()
    {
        if (targets.Count > 0)
        {
            Character nearest = targets[0];
            float distance = GlobalPosition.DistanceTo(nearest.GlobalPosition);
            for (int i = 0; i < targets.Count; i++)
            {
                float everyTargetDistance = GlobalPosition.DistanceTo(targets[i].GlobalPosition);

                if (everyTargetDistance <= distance)
                {
                    nearest = targets[i];
                    distance = everyTargetDistance;
                }
            }

            nearestTarget = nearest;
        }
    }
}