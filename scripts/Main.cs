using Godot;
using System;
using System.Collections.Generic;

public partial class Main : Node2D
{
	List<Node2D> existing_ally_sp = new List<Node2D>();
	List<Node2D> existing_hostile_sp = new List<Node2D>();
	List<Character> existing_characters = new List<Character>();

	public override void _Ready()
	{
		Node ally_house_res = GD.Load<PackedScene>("res://objects/building/ally/house.tscn").Instantiate();
		Node2D ally_house_instance = (Node2D)ally_house_res;

		ally_house_instance.Position = new Vector2(-28, -280);
		existing_ally_sp.Add(ally_house_instance);

		AddChild(ally_house_instance);
	}

	public void CheckInsertCharacter()
	{
		var _gameManager = GameManager.Instance.CheckCharacter();
		if (_gameManager.selectedCharacter != null)
		{
			Random rnd = new Random();
			int randomizeSpawnPoint;

			Character _character = null;

			if (_gameManager.variant == "knight")
			{
				_character = new Knight();
			}
			else if (_gameManager.variant == "barrel_goblin")
			{
				_character = new BarrelGoblin();
			}

			if (_gameManager.type == "ally")
			{
				randomizeSpawnPoint = rnd.Next(0, existing_ally_sp.Count);
				_gameManager.selectedCharacter.Position = existing_ally_sp[randomizeSpawnPoint].Position;
			}
			else if (_gameManager.type == "hostile")
			{
				randomizeSpawnPoint = rnd.Next(0, existing_hostile_sp.Count);
				_gameManager.selectedCharacter.Position = existing_hostile_sp[randomizeSpawnPoint].Position;
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
