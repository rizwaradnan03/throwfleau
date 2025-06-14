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
            Character _character = null;

            if (_gameManager.type == "ally")
            {
                if (_gameManager.variant == "knight")
                {
                    _character = new Knight();
                }

                allys.Add(_character);
            }
            else if (_gameManager.type == "hostile")
            {
                if (_gameManager.variant == "barrel_goblin")
                {
                    _character = new BarrelGoblin();
                }

                hostiles.Add(_character);
            }

            _gameManager.selectedCharacter.Name = _character.Id();

            AddChild(_gameManager.selectedCharacter);
            GameManager.Instance.ClearCharacter();
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
