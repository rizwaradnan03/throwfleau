using Godot;
using System;
using System.Numerics;

public partial class Player : CharacterBody2D
{
	private bool isMoving = false;
	private int speed = 200;

	private AnimatedSprite2D _animatedSprite2D;

	public void GetInput(double delta)
	{
		float x;
		float y;

		if (Input.IsActionPressed("move_up") || Input.IsActionPressed("move_down") || Input.IsActionPressed("move_right") || Input.IsActionPressed("move_left"))
		{
			if (Input.IsActionPressed("move_up"))
			{
				isMoving = true;
				_animatedSprite2D.Play("move_up");

				x += (float)(speed * delta);
			}
			else if (Input.IsActionPressed("move_down"))
			{
				x -= (float)(speed * delta);
				isMoving = true;
			}
		}
		else
		{
			isMoving = false;
		}

		if (isMoving == true)
		{
			Velocity = new Godot.Vector2(x, y);

			MoveAndSlide();
		}
	}

	public override void _Ready()
	{
		_animatedSprite2D = GetNode<AnimatedSprite2D>("Movement");
	}

	public override void _Process(double delta)
	{
		GetInput(delta);
	}
}
