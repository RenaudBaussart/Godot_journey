using Godot;
using System;
public partial class Score : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var baseScene = GetParent<BaseScene>();
		Text = baseScene.score.ToString();
	}
}
