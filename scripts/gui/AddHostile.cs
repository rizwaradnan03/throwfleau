using Godot;

public partial class AddHostile : Control
{
	public void _on_texture_button_pressed()
	{
        GameManager.Instance.SetTemporarySelectedCharacter("barrel_goblin");
	}
}
