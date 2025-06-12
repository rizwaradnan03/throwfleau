using Godot;
using System;
using System.Numerics;

public partial class Player : CharacterBody2D
{
	private bool isMoving = false;
	private int speed = 200;

	private AnimatedSprite2D _animatedSprite2D;

	public override void _Ready()
	{
		_animatedSprite2D = GetNode<AnimatedSprite2D>("Movement");
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("move_up") || Input.IsActionPressed("move_down") || Input.IsActionPressed("move_right") || Input.IsActionPressed("move_left"))
		{
			if (Input.IsActionPressed("move_up"))
            {
				isMoving = true;
				_animatedSprite2D.Play("move_up");
			}
			else if (Input.IsActionPressed("move_down"))
			{
				isMoving = true;
			}
		}
		else
		{
			isMoving = false;
		}


		if (isMoving == true)
		{
			// Velocity = new Vector2(delta)

			MoveAndSlide();
		}
	}
}
