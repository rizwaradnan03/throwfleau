using Godot;
using System.Collections.Generic;

public partial class Main : Node2D
{
	List<Character> existing_characters = new List<Character>();

	public void CheckInsertCharacter()
	{
		var _gameManager = GameManager.Instance.CheckCharacter();
		if (_gameManager.selectedCharacter != null)
		{
			Character _character = null;

			if (_gameManager.variant == "knight")
			{
				_character = new Knight();
			}
			else if (_gameManager.variant == "barrel_goblin")
			{
				_character = new BarrelGoblin();
			}

			_gameManager.selectedCharacter.Name = _character.Id();

			AddChild(_gameManager.selectedCharacter);
			GameManager.Instance.ClearCharacter();
		}
	}

	public void RealizingTargetAndFindNearest()
	{
		List<Character> allys = new List<Character>();
		List<Character> hostiles = new List<Character>();

		for (int i = 0; i < existing_characters.Count; i++)
		{
			if (existing_characters[i].Type() == "ally")
			{
				allys.Add(existing_characters[i]);
			}
			else
			{
				hostiles.Add(existing_characters[i]);
			}
		}

		for (int i = 0; i < existing_characters.Count; i++)
		{
			if (existing_characters[i].Type() == "ally")
			{
				existing_characters[i].RealizingTarget(hostiles);
			}
			else
			{
				existing_characters[i].RealizingTarget(allys);
			}
		}
	}

	public void MoveCharacter()
	{
		for (int i = 0; i < existing_characters.Count; i++)
		{
			existing_characters[i].FindNearestTarget();
		}
	}

	public override void _Process(double delta)
	{
		CheckInsertCharacter();
		RealizingTargetAndFindNearest();
		MoveCharacter();
	}
}
