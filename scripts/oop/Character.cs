using System;
using System.Collections.Generic;
using Godot;

public partial class Character : CharacterBody2D
{
    public string id;
    private int health;
    private string type;
    private string target;
    private int damage;
    protected double movementRange = 0.02;

    private List<Character> targets = new List<Character>();

    public Character(string Ptype)
    {
        type = Ptype;
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

    public double GetMovementRange()
    {
        return movementRange;
    }

    public virtual void SetMovementRange() { }

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

    public void FindNearestTargetAndMove()
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

            double x_pos = 0;
            double y_pos = 0;

            if (nearest.Position.X >= Position.X)
            {
                x_pos += movementRange;
            }
            else if (nearest.Position.X <= Position.X)
            {
                x_pos -= movementRange;
            }

            if (nearest.Position.Y >= Position.Y)
            {
                y_pos += movementRange;
            }
            else if (nearest.Position.Y <= Position.Y)
            {
                y_pos -= movementRange;
            }

            Velocity = new Godot.Vector2((float)x_pos, (float)y_pos);
            MoveAndSlide();
        }
    }
}