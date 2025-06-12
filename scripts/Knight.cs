using Godot;

public partial class Knight : StaticBody2D
{
    private Character _asAlly;

    public override void _Ready()
    {
        _asAlly = new Character("ally", 200, 14);
    }

    public override void _Process(double delta)
    {
        GD.Print("Jelas Paling Tulus Sak Dunia");
    }
}
