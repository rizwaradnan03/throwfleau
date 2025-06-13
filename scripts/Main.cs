using Godot;
using System.Collections.Generic;

public partial class Main : Node2D
{
    List<Character> allys = new List<Character>();
    List<Character> hostiles = new List<Character>();

    public void CheckInsertCharacter()
    {
        var _gameManager = GameManager.Instance.CheckCharacter();
        if (_gameManager.selectedCharacter != null)
        {

            Character newCharacter = new Character(_gameManager.type, _gameManager.variant);
            string characterType = newCharacter.Type();

            if (characterType == "ally")
            {
                allys.Add(newCharacter);
            }
            else if (characterType == "hostile")
            {
                hostiles.Add(newCharacter);
            }

            AddChild(_gameManager.selectedCharacter);
        }
    }

    public void MoveCharacter()
    {

    }

    public override void _Process(double delta)
    {
        CheckInsertCharacter();
        MoveCharacter();
    }
}
