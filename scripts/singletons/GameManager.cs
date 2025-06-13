using Godot;

public partial class GameManager : Node
{
    private StaticBody2D _selectedAddTroops;

    public static GameManager Instance{ get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }


    public void SetTroops(StaticBody2D _character)
    {
        _selectedAddTroops = _character;
    }

    public StaticBody2D CheckTroops()
    {
        return _selectedAddTroops;
    }

    public void ClearTroops()
    {
        _selectedAddTroops = null;
    }
}
