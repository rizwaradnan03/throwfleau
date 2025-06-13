using Godot;
using System.Collections.Generic;

public partial class Main : Node2D
{
    private GameManager _gameManager;
    List<Character> troops = new List<Character>();

    public override void _Ready()
    {
        base._Ready();
    }

    public void CheckInsertCharacter()
    {
        if (_gameManager.CheckTroops() != null)
        {

            Character newCharacter = new Character("ally", 100, 13);
            troops.Add(newCharacter);

            AddChild(_gameManager.CheckTroops());
        }
    }

    public override void _Process(double delta)
    {
        GD.Print("Nilai Troops : ", troops.Count);
        CheckInsertCharacter();
    }
}
