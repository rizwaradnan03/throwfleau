using Godot;
using System;

public partial class AddTroops : Control
{
	// private GameManager _gameManager;

	// public override void _Ready()
	// {
	// 	_gameManager = GameManager();
	// }


	public void _on_texture_button_pressed()
	{

		Node troop = GD.Load<PackedScene>("res://objects/allys/knight.tscn").Instantiate();
		StaticBody2D troopInstance = (StaticBody2D)troop;

		GameManager.Instance.SetTroops(troopInstance);
	}
}
