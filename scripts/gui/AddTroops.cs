using Godot;
using System;

public partial class AddTroops : Control
{
	public void _on_texture_button_pressed()
	{
		Node troop = GD.Load<PackedScene>("res://objects/allys/knight.tscn").Instantiate();
		Node hostile = GD.Load<PackedScene>("res://objects/hostiles/barrelgoblin.tscn").Instantiate();

		GameManager.Instance.SetCharacters((StaticBody2D)troop, "ally", "knight");
		GameManager.Instance.SetCharacters((StaticBody2D)hostile, "hostile", "barrel_goblin");
	}
}
