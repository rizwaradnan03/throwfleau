using Godot;
using System.Collections.Generic;

public partial class Main : Node2D
{
    List<Character> troops = new List<Character>();

    public void CheckInsertCharacter()
    {
        if (GameManager.Instance.CheckTroops() != null)
        {
            Character newCharacter = new Character("ally", 100, 13);
            troops.Add(newCharacter);

            AddChild(GameManager.Instance.CheckTroops());
        }
    }

    public override void _Process(double delta)
    {
        CheckInsertCharacter();
    }
}
