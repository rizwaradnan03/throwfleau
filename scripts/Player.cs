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
		float x_direction = 0;
		float y_direction = 0;

		if (Input.IsActionPressed("move_up") || Input.IsActionPressed("move_down") || Input.IsActionPressed("move_right") || Input.IsActionPressed("move_left"))
		{
			isMoving = true;
			if (Input.IsActionPressed("move_up") || Input.IsActionPressed("move_down"))
			{
				y_direction = 0;

				if (Input.IsActionPressed("move_up"))
				{
					_animatedSprite2D.Play("move_up");

					x_direction = (float)((speed * delta));
				}
				else if (Input.IsActionPressed("move_down"))
				{
					_animatedSprite2D.Play("move_down");

					x_direction -= (float)(speed * delta);
				}
			}
			else if (Input.IsActionPressed("move_right") || Input.IsActionPressed("move_left"))
			{
				x_direction = 0;

				if (Input.IsActionPressed("move_right"))
				{
					y_direction = (float)(y_direction + (speed * delta));
					_animatedSprite2D.Play("move_side");
					_animatedSprite2D.FlipH = false;
				}
				else if (Input.IsActionPressed("move_left"))
				{
					y_direction = (float)(y_direction - (speed * delta));
					_animatedSprite2D.Play("move_side");
					_animatedSprite2D.FlipH = true;
				}
			}
		}
		else
		{
			isMoving = false;
			_animatedSprite2D.Stop();
		}

		if (isMoving == true)
		{
			Velocity = new Godot.Vector2(x_direction, y_direction);

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
