using Godot;

public partial class Player : Area2D
{
	[Export]
	public int Speed { get; set; } = 400; // How fast the player will move (pixels/sec).
	public int NumberOfLife { get; set; } = 3; // How many hit the player take beffor die
	[Signal]
	public delegate void HitEventHandler();
	public Vector2 ScreenSize; // Size of the game window.
	
	public void OnBodyEntered(Node2D body){
		EmitSignal(SignalName.Hit);
		
		if (NumberOfLife <= 0) {
			Hide();
			GetNode<CollisionShape2D>("HitBox2D").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);
		} 
		
	}
	public void Start(Vector2 position)
	{
		Position = position;
		Show();
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
		NumberOfLife = 3;
	}
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		Hide();
	}
	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero; // The player's movement vector.

		if (Input.IsActionPressed("move_right"))
		{
			velocity.X += 1;
		}

		if (Input.IsActionPressed("move_left"))
		{
			velocity.X -= 1;
		}

		if (Input.IsActionPressed("move_down"))
		{
			velocity.Y += 1;
		}

		if (Input.IsActionPressed("move_up"))
		{
			velocity.Y -= 1;
		}

		var animatedSprite2D = GetNode<AnimatedSprite2D>("Sprite2D");

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite2D.Play();
		}
		else
		{
			animatedSprite2D.Stop();
		}
		//change the animation to fit the X or Y axis 
		if (velocity.X != 0)
		{
			animatedSprite2D.Animation = "walk";
			animatedSprite2D.FlipV = false;
			animatedSprite2D.FlipH = velocity.X < 0;
		}
		else if (velocity.Y != 0)
		{
			animatedSprite2D.Animation = "up";
			animatedSprite2D.FlipV = velocity.Y > 0;
		}
		//prevent player to leave the screen
		Position += velocity * (float)delta;
		Position = new Vector2(
		x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
		y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
);
	}
}
