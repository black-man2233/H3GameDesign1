using Godot;
using System;
using System.Diagnostics;

public partial class Sprite2d : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Debug.WriteLine("Ready");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		HandleMovement(delta);
	}

	private void HandleMovement(double delta)
	{
		float speed = 200f;

		// Check for key presses and update movement vector
		float x = 0;
		float y = 0;

		if (Input.IsActionPressed("ui_right"))
		{
			x += 1;
			Debug.WriteLine("rigth");
		}

		if (Input.IsActionPressed("ui_left"))
		{
			x -= 1;
			Debug.WriteLine("Left");
		}
		if (Input.IsActionPressed("ui_up"))
		{
			y -= 1;
			Debug.WriteLine("up");
		}
		if (Input.IsActionPressed("ui_down"))
		{
			y += 1;
			Debug.WriteLine("down");
		}

		// Create the movement vector
		Vector2 movement = new Vector2(x, y);

		// Normalize the movement vector to prevent faster diagonal movement
		if (movement.Length() > 0)
		{
			movement = movement.Normalized();
		}

		// Update the position based on the movement vector and speed
		this.Position += movement * speed * (float)delta;
		Console.WriteLine("Player moved");
	}
}
