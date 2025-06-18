using Godot;

public partial class GameManager : Node
{   
	private StaticBody2D _selectedCharacter;
	private string temporarySelectedCharacter;
	private string type;
	private string variant;

	public static GameManager Instance { get; private set; }

	public override void _Ready()
	{
		Instance = this;
	}

	public void SetTemporarySelectedCharacter(string PVariant)
	{
		// temporarySelectedCharacter = 
	}

	public void SetCharacters(string PVariant)
	{
		PackedScene packedTroop = null;

		if (PVariant == "knight")
		{
			packedTroop = GD.Load<PackedScene>("res://objects/allys/knight.tscn");
			type = "ally";
		}
		else if (PVariant == "barrel_goblin")
		{
			packedTroop = GD.Load<PackedScene>("res://objects/hostiles/barrelgoblin.tscn");
			type = "hostile";
		}

		variant = PVariant;
		_selectedCharacter = (StaticBody2D)packedTroop.Instantiate();
	}

	public (StaticBody2D selectedCharacter, string type, string variant) CheckCharacter()
	{
		return (_selectedCharacter, type, variant);
	}

	public void ClearCharacter()
	{
		_selectedCharacter = null;
		type = null;
		variant = null;
		temporarySelectedCharacter = null;
	}
}
