using Godot;

public partial class GameManager : Node
{
    private StaticBody2D _selectedCharacter;
    private string type;
    private string variant;
    
    public static GameManager Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }

    public void SetCharacters(StaticBody2D _character, string PType, string PVariant)
    {
        _selectedCharacter = _character;
        type = PType;
        variant = PVariant;
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
