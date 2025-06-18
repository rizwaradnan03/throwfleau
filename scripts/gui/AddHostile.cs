using Godot;

public partial class AddHostile : Control
{
	public void _on_texture_button_pressed()
	{
				GameManager.Instance.SetCharacters("barrel_goblin");

		// GameManager.Instance.SetTemporarySelectedCharacter("barrel_goblin");
	}
}
