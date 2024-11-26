using Godot;
using System;
public partial class BaseScene : Node2D
{
	public int score = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	public void AddToScore(int scoreToAdd){
		score += scoreToAdd;
	}
	public void RemoveToScore(int scoreToRemove){
		score -= scoreToRemove;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
