using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node
{
    Dictionary<string, object> player = new Dictionary<string, object>
    {
        {"health", 100},
        {"isDead", false},
    };

    public bool DecrementHealth(int amount)
    {
        int currentHealth = (int)player["health"];

        currentHealth -= amount;
        player["health"] = currentHealth;
        bool current_is_dead = (bool)player["is_dead"];

        if (currentHealth <= 0)
        {
            current_is_dead = true;
        }
        else
        {
            current_is_dead = false;
        }

        return current_is_dead;
    }
}
