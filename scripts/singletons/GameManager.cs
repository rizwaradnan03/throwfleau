using Godot;

public partial class GameManager : Node
{
    private StaticBody2D _selectedAddTroops;

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
