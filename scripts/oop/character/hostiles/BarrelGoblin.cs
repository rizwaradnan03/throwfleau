public partial class BarrelGoblin : Character
{
    public BarrelGoblin(string Ptype) : base(Ptype)
    {

    }
    
    public override void SetMovementRange()
    {
        movementRange = 0.0;
    }
}