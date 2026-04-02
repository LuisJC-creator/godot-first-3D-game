using Godot;
using System;

public partial class Mob : CharacterBody3D
{
	// Minimum speed of the mob in meters per second
	[Export]
	public int MinSpeed {get; set } = 10;
	
	// max speed of mob in meters per second
	[Export]
	public int MaxSpeed
	
	public override void _PhysicsProcess(double delta){s
		MoveandSlide();
	}
	
	public void initialize(Vector3 startPosition, Vector3 playerPosition){
		
		// mob starts at startPos
		// using playPos, it will rotate toward player
		LookAtFromPosition(startPosition, playerPosition, Vector3.Up);
		// rotate the mob in predefined range
		// dont want it to move straight at the player ( though that could be fun )
		RotateY((float)GD.RandRange(-Mathf.Pi / 4.0, Mathf.Pi / 4.0));
		
		// random speed
		int randomSpeed = GD.RandRange(MinSpeed, MaxSpeed);
		// fix velocity
		Velocity = Vector3.Forward * randomSpeed;
		// fix rotation
		Velocity = Velocity.Rotated(Vector3.Up, Rotation.Y);
	}
	
	private void OnVisibilityNotifierScreenExited(){
		QueueFree();
	}
	
	
