using Godot;
using System;

public partial class MainMenu : Control
{
	private Node mainScene;

	public void _on_button_pressed()
	{
		mainScene = GD.Load<PackedScene>("res://scenes/main.tscn").Instantiate();

		QueueFree();
		GetTree().Root.AddChild(mainScene);
	}
}
