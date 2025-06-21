
public partial class Knight : Character
{
	public Knight(string Ptype) : base(Ptype)
	{

	}

	public override void SetMovementRange()
	{
		movementRange = 0.02;
	}
}
