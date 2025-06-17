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

    public void SetCharacters(string PVariant)
    {
        Node troop = null;

        if (PVariant == "knight")
        {
            troop = GD.Load<PackedScene>("res://objects/allys/knight.tscn").Instantiate();
            variant = PVariant;
            type = "ally";
        }
        _selectedCharacter = (StaticBody2D)troop;
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
    }
}
